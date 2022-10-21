class Dropdown {
    constructor(id = "userDP") {
        this.msalconfig = {
            auth: {
                clientId: "191d0109-d1e7-44c8-a9b4-55316ac752d8",
                authority: "https://login.microsoftonline.com/4cc65fd6-9c76-4871-a542-eb12a5a7800c",
                redirectUri: "https://teamconnect.firstam.net/",
            },
            cache: {
                cacheLocation: "sessionStorage",
                storeAuthStateInCookie: false
            }
        }
        this.MSALObj = new msal.PublicClientApplication(this.msalconfig);
        this.appendUserDropdown = id
        this.currentUserName = ""

    }
    signIn() {
        const loginScope = {
            scope: ["User.Read"]
        }
        this.MSALObj.loginRedirect(loginScope)
    }
    signOut() {
        const logoutReq = {
            account: this.MSALObj.getAccountByUsername(this.currentUserName)
        }
        this.MSALObj.logoutRedirect(logoutReq)
    }
    selectAccount() {
        const accounts = this.MSALObj.getAllAccounts();
        if (accounts.length === 0) {
            return;
        } else if (accounts.length > 1) {
            console.log("multiple accounts")
        } else if (accounts.length === 1) {
            return accounts[0].name;
        }
    }
    addHtmlDropdown(user) {
        if (user) {
            // adding the html component
            let html = `
                <div>
                    <div class="dropdown">
                        <button class="dropbtn"><span class="glyphicon glyphicon-user" aria-hidden="true"></span> ${user}</button>
                        <div class="dropdown-content">
                            <button id="btnSignOut" type="button" class="btn btn-default btn-md">
                                <span class="glyphicon glyphicon-log-out" aria-hidden="true"></span> Sign out
                            </button>
                        </div>
                    </div>
                </div>`;
            document.getElementById(this.appendUserDropdown).innerHTML = html;

            // adding the onClick event
            let btn = document.getElementById("btnSignOut");
            btn.addEventListener('click', event => {
              this.signOut();
            });
        } else {
            console.error("Need to pass the user paramter")
            return "Need to pass the user paramter"
        }
    }
}

// onLoad event
window.addEventListener("load", function () {
    let myDropdown = new Dropdown();

    // catch the response event from MSAL
    myDropdown.MSALObj.handleRedirectPromise()
        .then((response) => {
            if (response != null) {
                myDropdown.currentUserName = response.account.username;
                myDropdown.addHtmlDropdown(response.account.name)
            } else {
                myDropdown.selectAccount();
            }
        }).catch((err) => {
            console.error(err);
        })
    
    myDropdown.signIn();
});