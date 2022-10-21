
function GetCharts() {
  google.charts.load('current', {
    packages: ["orgchart"]
  });
  google.charts.setOnLoadCallback(buildCharts);
}

function buildCharts(){
  buildCalculatorsChart();
  buildIgniteREChart();
  buildIgniteChart();
}

function buildCalculatorsChart() {
  var xmlhttp = new XMLHttpRequest();
  var url = "https://g5nqcxqll8.execute-api.us-west-2.amazonaws.com/product-chart-dev/product-chart";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var chartData = JSON.parse(xmlhttp.responseText);
      drawCalculatorsChart(chartData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
}

function buildIgniteREChart() {
  var xmlhttp = new XMLHttpRequest();
  var url = "https://g5nqcxqll8.execute-api.us-west-2.amazonaws.com/product-chart-dev/ignitere-chart";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var chartData = JSON.parse(xmlhttp.responseText);
      drawIgniteREChart(chartData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
}

function buildIgniteChart() {
  var xmlhttp = new XMLHttpRequest();
  var url = "https://g5nqcxqll8.execute-api.us-west-2.amazonaws.com/product-chart-dev/ignite-chart";


  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      var chartData = JSON.parse(xmlhttp.responseText);
      drawIgniteChart(chartData);
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
}

function drawCalculatorsChart(chartData) {
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'Role');
  data.addColumn('string', 'ToolTip');

  // For each orgchart box, provide the name, manager, and tooltip to show.
  data.addRows(chartData);
  //data.setRowProperty(1, 'style', 'background:green');
  // Create the chart.
  var chart = new google.visualization.OrgChart(document.getElementById('chart_calculators'));
  // Draw the chart, setting the allowHtml option to true for the tooltips.
  chart.draw(data, {
    'allowHtml': true
  });
}

function drawIgniteREChart(chartData) {
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'Role');
  data.addColumn('string', 'ToolTip');

  // For each orgchart box, provide the name, manager, and tooltip to show.
  data.addRows(chartData);
  //data.setRowProperty(1, 'style', 'background:green');
  // Create the chart.
  var chart = new google.visualization.OrgChart(document.getElementById('chart_ignitere'));
  // Draw the chart, setting the allowHtml option to true for the tooltips.
  chart.draw(data, {
    'allowHtml': true
  });
}

function drawIgniteChart(chartData) {
  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Name');
  data.addColumn('string', 'Role');
  data.addColumn('string', 'ToolTip');

  // For each orgchart box, provide the name, manager, and tooltip to show.
  data.addRows(chartData);
  //data.setRowProperty(1, 'style', 'background:green');
  // Create the chart.
  var chart = new google.visualization.OrgChart(document.getElementById('chart_ignite'));
  // Draw the chart, setting the allowHtml option to true for the tooltips.
  chart.draw(data, {
    'allowHtml': true
  });
}
