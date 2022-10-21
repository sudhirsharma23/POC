
var token;
var apiKey = "PQuaOL61GXeCQK4OL7FV9ldl4ec13Ef7cD7F1zId";
var source = "calc";

function GetToken() {
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    if(this.readyState === 4) {
      token = this.responseText;
      console.log(token);
    }
  });  
  xhr.open("GET", "https://4ygxoqifxg.execute-api.us-west-2.amazonaws.com/dev/token");  
  xhr.send(null);
}

function GetState(edate){
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    $('#spinnerDiv').show();
    $('#loadingSpan').text("Loading Property States");
    if(this.readyState === 4 && this.status == 200) {      
      $('#propertyState').empty();
      var statesRes = this.responseText;
      console.log("States:");
      console.log(statesRes);
      var statesJson = eval(statesRes);
      var len = statesJson.length;
      var propStateDropdown = document.getElementById("propertyState");      
      for(var i=0;i < len;i ++){
        var option = document.createElement('option');
        option.text = option.value = statesJson[i].name;
        propStateDropdown.add(option,i);
      }
      var selectOption = document.createElement('option');
      selectOption.text = "Select";
      selectOption.value = "";
      propStateDropdown.add(selectOption,0);
      propStateDropdown.selectedIndex = 0;
      $('#spinnerDiv').hide();
      $('#loadingSpan').text("Loading...");
    }
  });  
  xhr.open("GET", "https://dev.api.rates.firstam.net/shell/states?source="+source+"&effectiveDate="+edate), true;  
  xhr.setRequestHeader("x-api-key", apiKey);
  xhr.setRequestHeader("Authorization", "Bearer "+token);
  xhr.send(null);
}

function GetClosingState(edate){
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    if(this.readyState === 4 && this.status == 200) {
      $('#closingOfficeState').empty();
      var statesRes = this.responseText;
      console.log("States:");
      console.log(statesRes);
      var statesJson = eval(statesRes);
      var len = statesJson.length;
      var closingStateDropdown = document.getElementById("closingOfficeState");
      for(var i=0;i < len;i ++){
        if(!statesJson[i].closing){
          continue;
        }
        var option = document.createElement('option');
        option.text = option.value = statesJson[i].name;
        closingStateDropdown.add(option,i);
      }
      var selectOption = document.createElement('option');
      selectOption.text = "Select";
      selectOption.value = "";
      closingStateDropdown.add(selectOption,0);
      closingStateDropdown.selectedIndex = 0;
    }
  });  
  xhr.open("GET", "https://dev.api.rates.firstam.net/shell/states?source="+source+"&effectiveDate="+edate), true;  
  xhr.setRequestHeader("x-api-key", apiKey);
  xhr.setRequestHeader("Authorization", "Bearer "+token);
  xhr.send(null);
}

function GetCounty(edate, state){
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    $('#spinnerDiv').show();
    $('#loadingSpan').text("Loading Property Counties");
    if(this.readyState === 4) {
      $('#propertyCounty').empty();
      var countiesRes = this.responseText;
      console.log("Counties:");
      console.log(countiesRes);
      var countiesJson = eval(countiesRes);
      var len = countiesJson.length;
      var propCountyDropdown = document.getElementById("propertyCounty");
      for(var i=0;i < len;i ++){
        var option = document.createElement('option');
        option.text = option.value = countiesJson[i].name;
        propCountyDropdown.add(option,i);
      }
      var selectOption = document.createElement('option');
      selectOption.text = "Select";
      selectOption.value = "";
      propCountyDropdown.add(selectOption,0);
      propCountyDropdown.selectedIndex = 0; 
      $('#spinnerDiv').hide();
      $('#loadingSpan').text("Loading...");
    }
  });  
  xhr.open("GET", "https://dev.api.rates.firstam.net/shell/counties?source="+source+"&effectiveDate="+edate+"&state="+state);  
  xhr.setRequestHeader("x-api-key", apiKey);
  xhr.setRequestHeader("Authorization", "Bearer "+token);
  xhr.send(null);
}

function GetClosingCounty(edate, state){
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    $('#spinnerDiv').show();
    $('#loadingSpan').text("Loading Closing Counties");
    if(this.readyState === 4) {
      $('#closingOfficeCounty').empty();
      var countiesRes = this.responseText;
      console.log("Counties:");
      console.log(countiesRes);
      var countiesJson = eval(countiesRes);
      var len = countiesJson.length;
      var closingOfficeCountyDropdown = document.getElementById("closingOfficeCounty");
      for(var i=0;i < len;i ++){
        if(!countiesJson[i].closing){
          continue;
        }
        var option = document.createElement('option');
        option.text = option.value = countiesJson[i].name;
        closingOfficeCountyDropdown.add(option,i);
      }
      var selectOption = document.createElement('option');
      selectOption.text = "Select";
      selectOption.value = "";
      closingOfficeCountyDropdown.add(selectOption,0);
      closingOfficeCountyDropdown.selectedIndex = 0; 
      $('#spinnerDiv').hide();
      $('#loadingSpan').text("Loading...");
    }
  });  
  xhr.open("GET", "https://dev.api.rates.firstam.net/shell/counties?source="+source+"&effectiveDate="+edate+"&state="+state);  
  xhr.setRequestHeader("x-api-key", apiKey);
  xhr.setRequestHeader("Authorization", "Bearer "+token);
  xhr.send(null);
}

function GetPropertyType(edate, state){
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    if(this.readyState === 4) {
      $('#propertyType').empty();
      var propTypesRes = this.responseText;
      console.log("Property Types:");
      console.log(propTypesRes);
      var propTypesJson = eval(propTypesRes);
      var len = propTypesJson.length;
      var propTypesDropdown = document.getElementById("propertyType");
      for(var i=0;i < len;i ++){
        var option = document.createElement('option');
        option.text = propTypesJson[i].name; 
        option.value = propTypesJson[i].id;
        propTypesDropdown.add(option,i);
      }
      var selectOption = document.createElement('option');
      selectOption.text = "Select";
      selectOption.value = "";
      propTypesDropdown.add(selectOption,0);
      propTypesDropdown.selectedIndex = 0; 
    }
  });  
  xhr.open("GET", "https://dev.api.rates.firstam.net/shell/propertytypes?source="+source+"&effectiveDate="+edate+"&state="+state);  
  xhr.setRequestHeader("x-api-key", apiKey);
  xhr.setRequestHeader("Authorization", "Bearer "+token);
  xhr.send(null);
}

function GetCity(edate, state, county){
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    $('#spinnerDiv').show();
    $('#loadingSpan').text("Loading Property Cities");
    if(this.readyState === 4) {
      $('#propertyCity').empty();
      var citiesRes = this.responseText;
      console.log("Cities:");
      console.log(citiesRes);
      var citiesJson = eval(citiesRes);
      var len = citiesJson.length;
      var citiesDropdown = document.getElementById("propertyCity");
      for(var i=0;i < len;i ++){
        var option = document.createElement('option');
        option.text = option.value = citiesJson[i].name; 
        citiesDropdown.add(option,i);
      }
      var selectOption = document.createElement('option');
      selectOption.text = "Select";
      selectOption.value = "";
      citiesDropdown.add(selectOption,0);
      citiesDropdown.selectedIndex = 0; 
      $('#spinnerDiv').hide();
      $('#loadingSpan').text("Loading...");
    }
  });  
  xhr.open("GET", "https://dev.api.rates.firstam.net/shell/cities?source="+source+"&effectiveDate="+edate+"&state="+state+"&county="+county);  
  xhr.setRequestHeader("x-api-key", apiKey);
  xhr.setRequestHeader("Authorization", "Bearer "+token);
  xhr.send(null);
}

function GetTransactionType(edate, state){
  var xhr = new XMLHttpRequest();    
  xhr.addEventListener("readystatechange", function() {
    if(this.readyState === 4) {
      $('#transactionType').empty();
      var txTypesRes = this.responseText;
      console.log("TX Types:");
      console.log(txTypesRes);
      var txTypesJson = eval(txTypesRes);
      var len = txTypesJson.length;
      var txTypesDropdown = document.getElementById("transactionType");
      for(var i=0;i < len;i ++){
        var option = document.createElement('option');
        option.text = txTypesJson[i].name; 
        option.value = txTypesJson[i].id
        txTypesDropdown.add(option,i);
      }
      var selectOption = document.createElement('option');
      selectOption.text = "Select";
      selectOption.value = "";
      txTypesDropdown.add(selectOption,0);
      txTypesDropdown.selectedIndex = 0; 
    }
  });  
  xhr.open("GET", "https://dev.api.rates.firstam.net/shell/transactiontypes?source="+source+"&effectiveDate="+edate+"&state="+state);  
  xhr.setRequestHeader("x-api-key", apiKey);
  xhr.setRequestHeader("Authorization", "Bearer "+token);
  xhr.send(null);
}


