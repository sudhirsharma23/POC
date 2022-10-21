function GetCerts(){
    google.charts.load('current', {'packages':['table']});
    google.charts.setOnLoadCallback(buildTables);
}

function buildTables() {
    buildAWSCertTable();
    buildHashiCorpCertTable();
    buildContributorTable();
    buildKubernetesTable();
    buildAzureTable();
    buildMSTable();
    buildScrumTable();
    buildItilTable();
}

function buildAWSCertTable(){
    var xmlhttp = new XMLHttpRequest();
    var url = "#{api-uri}#/aws-certified";
  
  
    xmlhttp.onreadystatechange = function() {
      if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
        var tableData = JSON.parse(xmlhttp.responseText);
        drawAWSTable(tableData);
      }
    }
  
    xmlhttp.open("GET", url, true);
    xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
    xmlhttp.send(null);
}

function buildHashiCorpCertTable(){
    var xmlhttp = new XMLHttpRequest();
    var url = "#{api-uri}#/hashicorp-certified";
  
  
    xmlhttp.onreadystatechange = function() {
      if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
        var tableData = JSON.parse(xmlhttp.responseText);
        drawHashiCorpTable(tableData);
      }
    }
  
    xmlhttp.open("GET", url, true);
    xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
    xmlhttp.send(null);
}

function buildContributorTable(){
    var xmlhttp = new XMLHttpRequest();
    var url = "#{api-uri}#/contributor";
  
  
    xmlhttp.onreadystatechange = function() {
      if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
        var tableData = JSON.parse(xmlhttp.responseText);
        drawContributorTable(tableData);
      }
    }
  
    xmlhttp.open("GET", url, true);
    xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
    xmlhttp.send(null);
}

function buildKubernetesTable(){
  var xmlhttp = new XMLHttpRequest();
  var url = "#{api-uri}#/kubernetes-certified";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var tableData = JSON.parse(xmlhttp.responseText);
      drawKubernetesTable(tableData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
  xmlhttp.send(null);
}

function buildAzureTable(){
  var xmlhttp = new XMLHttpRequest();
  var url = "#{api-uri}#/azure-certified";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var tableData = JSON.parse(xmlhttp.responseText);
      drawAzureTable(tableData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
  xmlhttp.send(null);
}

function buildMSTable(){
  var xmlhttp = new XMLHttpRequest();
  var url = "#{api-uri}#/ms-certified";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var tableData = JSON.parse(xmlhttp.responseText);
      drawMSTable(tableData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
  xmlhttp.send(null);
}

function buildScrumTable(){
  var xmlhttp = new XMLHttpRequest();
  var url = "#{api-uri}#/scrum-certified";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var tableData = JSON.parse(xmlhttp.responseText);
      drawScrumTable(tableData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
  xmlhttp.send(null);
}

function buildItilTable(){
  var xmlhttp = new XMLHttpRequest();
  var url = "#{api-uri}#/itil-certified";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var tableData = JSON.parse(xmlhttp.responseText);
      drawItilTable(tableData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.setRequestHeader("x-api-key", "#{x-api-key}#");
  xmlhttp.send(null);
}



function drawAWSTable(tableData){
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Name');
    data.addColumn('string', 'Cloud Practitioner');
    data.addColumn('string', 'Developer Asso.');
    data.addColumn('string', 'SysOps Administrator Asso.');             
    data.addColumn('string', 'Solutions Architect Asso.');
    data.addColumn('string', 'DevOps Pro.');
    data.addColumn('string', 'Solutions Architect Pro.');
    data.addColumn('string', 'Advanced Networking Specialty');
    data.addColumn('string', 'Security Specialty');
    data.addColumn('string', 'Machine Learning Specialty');
    data.addColumn('string', 'Data Analytics Specialty');
    data.addColumn('string', 'Database Specialty');
    data.addRows(tableData);
    var table = new google.visualization.Table(document.getElementById('table_aws'));

    table.draw(data, {showRowNumber: true, width: '100%', height: '100%', 'allowHtml':true});
}

function drawHashiCorpTable(tableData){
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Name');
    data.addColumn('string', 'Terraform Associate');
    data.addColumn('string', 'Vault Associate');
    data.addColumn('string', 'Consul Associate');             
    data.addColumn('string', 'Vault Operations Professional');    
    data.addRows(tableData);
    var table = new google.visualization.Table(document.getElementById('table_hashicorp'));

    table.draw(data, {showRowNumber: true, width: '70%', height: '100%', 'allowHtml':true});
}

function drawContributorTable(tableData){
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Name');
    data.addColumn('string', 'AWS Community Builders');
    data.addColumn('string', 'HashiCorp Ambassadors');
    data.addRows(tableData);
    var table = new google.visualization.Table(document.getElementById('table_contributor'));

    table.draw(data, {showRowNumber: true, width: '40%', height: '100%', 'allowHtml':true});
}


function drawKubernetesTable(tableData){
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'Kubernetes Administrator');
  data.addColumn('string', 'Kubernetes Application Devloper');
  data.addColumn('string', 'Kubernetes Security Specialist');
  data.addColumn('string', 'Kubernetes and Cloud Native Associate');
  data.addRows(tableData);
  var table = new google.visualization.Table(document.getElementById('table_Kubernetes'));

  table.draw(data, {showRowNumber: true, width: '70%', height: '100%', 'allowHtml':true});
}

function drawAzureTable(tableData){
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'Azure Fundamentals');
  data.addColumn('string', 'Azure Solutions Architect Expert');
  data.addColumn('string', 'DevOps Engineer Expert');
  data.addColumn('string', 'Azure Developer Associate');
  data.addColumn('string', 'Azure Security Engineer Associate');
  data.addColumn('string', 'Azure Network Engineer Associate');
  data.addColumn('string', 'Azure Administrator Associate');
  data.addColumn('string', 'Azure Database Administrator Associate');
  data.addRows(tableData);
  var table = new google.visualization.Table(document.getElementById('table_azure'));

  table.draw(data, {showRowNumber: true, width: '100%', height: '100%', 'allowHtml':true});
}

function drawMSTable(tableData){
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'MC Application Developer');
  data.addColumn('string', 'MC Solution Developer');
  data.addColumn('string', 'MC Professional');  
  data.addColumn('string', 'MC Solution Expert');  
  data.addRows(tableData);
  var table = new google.visualization.Table(document.getElementById('table_ms'));

  table.draw(data, {showRowNumber: true, width: '70%', height: '100%', 'allowHtml':true});
}

function drawScrumTable(tableData){
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'Certified ScrumMaster');
  data.addColumn('string', 'Certified Scrum Product Owner');
  data.addColumn('string', 'Certified Scrum Developer');  
  data.addColumn('string', 'Advanced Certified ScrumMaster');  
  data.addRows(tableData);
  var table = new google.visualization.Table(document.getElementById('table_scrum'));

  table.draw(data, {showRowNumber: true, width: '70%', height: '100%', 'allowHtml':true});
}

function drawItilTable(tableData){
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'ITIL Founcation');
  data.addColumn('string', 'ITIL Managing Professional');
  data.addColumn('string', 'ITIL Strategic Leader');  
  data.addColumn('string', 'ITIL Specialist');  
  data.addRows(tableData);
  var table = new google.visualization.Table(document.getElementById('table_itil'));

  table.draw(data, {showRowNumber: true, width: '70%', height: '100%', 'allowHtml':true});
}