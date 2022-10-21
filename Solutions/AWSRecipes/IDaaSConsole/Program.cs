using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDaaSConsoleFramework
{
    class Program
    {

        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                Console.WriteLine("Pass client id and key");
                return;
            }
            var clientID = args[0];
            var clientKey = args[1];
            Console.WriteLine("Press anykey to sign in ... ");
            Console.ReadKey();
            var p = new Program();
            
            p.doOAuth(clientID, clientKey);
            Console.ReadKey();
        }

        private async void doOAuth(string clientID, string clientKey)
        {
            try
            {
                string redirectURI = "http://localhost:44305/";
                output("redirect URI: " + redirectURI);

                var state = RandomDataBase64url(32);
                var idassURL = "https://dev.login.firstam.com/myidaasdev.onmicrosoft.com/oauth2/v2.0/authorize";
             
                var policy = "b2c_1a_fa_eid_signin";
                var http = new HttpListener();
                http.Prefixes.Add(redirectURI);
                output("Listening..");
                http.Start();
                var scope = "openid";
                var redirectURIEscaped = System.Uri.EscapeDataString(redirectURI);
                var authorizationRequest = $"{idassURL}?p={policy}&client_id={clientID}&redirect_uri={redirectURIEscaped}&response_type=code&scope={scope}&state={state}";
                
                System.Diagnostics.Process.Start(authorizationRequest);

                var context = await http.GetContextAsync();
                
                //BringConsoleToFront();
                
                var response = context.Response;
                string responseString = string.Format("<html><head><meta http-equiv='refresh' content='1;url=https://rtminfo.firstam.com/RtmInfo/index.html'></head><body>Please return to the app.</body></html>");
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                var responseOutput = response.OutputStream;
                Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
                {
                    responseOutput.Close();
                    http.Stop();
                    Console.WriteLine("HTTP server stopped.");
                });

                
                if (context.Request.QueryString.Get("error") != null)
                {
                    output(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                    return;
                }
                if (context.Request.QueryString.Get("code") == null
                    || context.Request.QueryString.Get("state") == null)
                {
                    output("Malformed authorization response. " + context.Request.QueryString);
                    return;
                }

               
                var code = context.Request.QueryString.Get("code");
                var incoming_state = context.Request.QueryString.Get("state");

               
                if (incoming_state != state)
                {
                    output(String.Format("Received request with invalid state ({0})", incoming_state));
                    return;
                }
                output("Authorization code: " + code);



                var tokenRequestURL = $"https://login.microsoftonline.com/myidaasdev.onmicrosoft.com/oauth2/v2.0/token?p={policy}";
                
                var grantType = "authorization_code";
                var codeValue = code;
               
                var body = $"code={codeValue}&redirect_uri={redirectURIEscaped}&client_id={clientID}&client_secret={clientKey}&grant_type={grantType}";

                HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenRequestURL);
                tokenRequest.Method = "POST";
                tokenRequest.ContentType = "application/x-www-form-urlencoded";
                tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                byte[] _byteVersion = Encoding.ASCII.GetBytes(body);
                tokenRequest.ContentLength = _byteVersion.Length;
                Stream stream = tokenRequest.GetRequestStream();
                await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length);
                stream.Close();

                try
                {
                    WebResponse tokenResponse = await tokenRequest.GetResponseAsync();
                    using (StreamReader reader = new StreamReader(tokenResponse.GetResponseStream()))
                    {
                        string responseText = await reader.ReadToEndAsync();
                        Console.WriteLine(responseText);

                        Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                        string profile_info = tokenEndpointDecoded["profile_info"];
                        output($"profile_info: {profile_info}");

                       
                        string id_token = tokenEndpointDecoded["id_token"];
                        output($"id_token: {id_token}");

                        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(id_token);
                        var claims = token.Claims.ToDictionary(c => c.Type, c => c.Value);

                        var username = claims["UserName"];
                        var azureObjectID = claims["AzureObjectID"];
                        output($"Username: {username}");
                        output($"AzureObjectID: {azureObjectID}");

                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var tokenresponse = ex.Response as HttpWebResponse;
                        if (tokenresponse != null)
                        {
                            output("HTTP: " + tokenresponse.StatusCode);
                            using (StreamReader reader = new StreamReader(tokenresponse.GetResponseStream()))
                            {
                                string responseText = await reader.ReadToEndAsync();
                                output(responseText);
                            }
                        }

                    }
                }
            }
            catch(Exception e)
            {
                output(e.StackTrace);
            }
        }

        public void output(string output)
        {
            Console.WriteLine(output);
        }

        //[DllImport("kernel32.dll", ExactSpelling = true)]
        //public static extern IntPtr ConsoleWindow { get; }

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool SetForegroundWindow(IntPtr hWnd);

        //public void BringConsoleToFront()
        //{
        //    _ = SetForegroundWindow(ConsoleWindow);
        //}

        public static string RandomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return base64urlencodeNoPadding(bytes);
        }

   
        public static byte[] sha256(string inputStirng)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputStirng);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }

       
        public static string base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            // Strips padding.
            base64 = base64.Replace("=", "");

            return base64;
        }
    }
}
