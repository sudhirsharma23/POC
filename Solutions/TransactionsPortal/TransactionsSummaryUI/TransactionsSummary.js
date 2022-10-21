var txList = undefined;
var reportTxType = undefined;
var reportRegion = undefined;
var reportPropertyType = undefined;
var reportBusSegment = undefined;

function GetReports() {
 
  google.charts.load('current', {
    'packages': ['corechart', 'table']
  });
  google.charts.setOnLoadCallback(DrawReports);
}

function DrawReports() {
  GetTransactions();
  GetReprotTransactionType();

}

function AutoRefresh(t) {
  setTimeout("location.reload(true);", t);
}

function GetTransactions() {
  var xmlhttp = new XMLHttpRequest();
  var url = "#{tx-report-sb-uri}#/toptransactions";
  

  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      txList = JSON.parse(xmlhttp.responseText);
      DrawTxTable();
    }
  }

  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
 
} 

function GetReprotTransactionType() {
  var xmlhttp = new XMLHttpRequest();
  var url = "#{tx-report-dev-uri}#/transactiontypereport";
  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      reportTxType = JSON.parse(xmlhttp.responseText);
      DrawTxTypeReport();
    }
  }
  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
}

function GetReportRegion() {
  var xmlhttp = new XMLHttpRequest();
  var url = "#{tx-report-dev-uri}#/regionreport";
  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      reportRegion = JSON.parse(xmlhttp.responseText);
    }
  }
  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
}

function GetReportPropertyType() {
  var xmlhttp = new XMLHttpRequest();
  var url = "#{tx-report-dev-uri}#/propertytypereport";
  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      reportPropertyType = JSON.parse(xmlhttp.responseText);
    }
  }
  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
}

function GetReportBusSegment() {
  var xmlhttp = new XMLHttpRequest();
  var url = "#{tx-report-dev-uri}#/businesssegmentreport";
  xmlhttp.onreadystatechange = function() {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      reportBusSegment = JSON.parse(xmlhttp.responseText);
    }
  }
  xmlhttp.open("GET", url, true);
  xmlhttp.send(null);
}



function DrawReports2() {
  DrawTxTable();
  if (reportTxType) DrawTxTypeReport();
  if (reportRegion) DrawRegionReport();
  if (reportPropertyType) DrawPropertyTypeReport();
  if (reportBusSegment) DrawBusSegmentReport();
}

function DrawTxTable() {
  
  var topTx_table = new google.visualization.DataTable();
  topTx_table.addColumn('string', 'Property Address');
  topTx_table.addColumn('string', 'State');
  topTx_table.addColumn('string', 'Open Date');
  topTx_table.addColumn('string', 'Est Close Date');
  topTx_table.addColumn('string', 'Buyer');
  topTx_table.addColumn('string', 'Seller');
  for (i = 0; i < txList.length; i++) {
    topTx_table.addRows([
      [txList[i].PropertyAddress, txList[i].State, txList[i].OpenDate, txList[i].EstimateCloseDate, txList[i].Buyer, txList[i].Seller]
    ]);
  }
  var options_topTx_table = {
    title: 'Transactions Summary'
  };
  var table = new google.visualization.Table(document.getElementById('TransactionsSummaryTable'));
  table.draw(topTx_table, {
    showRowNumber: true,
    width: '100%',
    height: '100%'
  }, options_topTx_table);
}

function DrawTxTypeReport() {
  var countByTxType_table = new google.visualization.DataTable();
  countByTxType_table.addColumn('string', 'Transaction Type');
  countByTxType_table.addColumn('number', 'Count');
  for (i = 0; i < reportTxType.DataItems.length; i++) {
    countByTxType_table.addRows([
      [reportTxType.DataItems[i].Name, reportTxType.DataItems[i].Number]
    ]);
  }
  var countByTxTypeoptions = {
    title: 'Transaction Type',
    is3D: true
  };
  var countByTxTypechart = new google.visualization.PieChart(document.getElementById('countByTxType'));
  countByTxTypechart.draw(countByTxType_table, countByTxTypeoptions);

  var countByTxTypeBarOptions = {
    title: '',
    width: 800,
    height: 700,
    legend: {
      position: 'none'
    },
    chart: {
      subtitle: '{Date}'
    },
    axes: {
      x: {
        0: {
          side: 'bottom',
          label: 'Transaction Type'
        }
      },
      y: {
        0: {
          label: 'Count'
        }
      }
    },
    bar: {
      groupWidth: "30%"
    }
  };
  var countByTxTypeBarChart = new google.visualization.ColumnChart(document.getElementById('countByTxTypeBarChart'));
  countByTxTypeBarChart.draw(countByTxType_table, countByTxTypeBarOptions);
}

function DrawRegionReport() {
  var countByRegion = google.visualization.arrayToDataTable([
    ['Region', 'Count'],
    ['Southeast Region', 2092],
    ['California', 1346],
    ['Northwest', 985],
    ['Regional Lenders Advantage', 542],
    ['South Central Region', 425],
    ['National Commercial Services Division', 384],
    ['Southwest', 327],
    ['Affiliated', 314],
    ['Mortgage Services', 314],
    ['Midwest Region', 266],
    ['East', 231],
    ['New York', 206],
    ['Metropolitan', 182],
    ['Republic Title', 138],
    ['Western Resources Title', 137],
    ['North Central', 118],
    ['National Default Title Services', 116],
    ['Nevada Region', 100],
    ['IndMetro', 99],
    ['Carefree Title Agency, Inc.', 73],
    ['Partnership Division', 72],
    ['Great American Title', 56],
    ['Holland', 40],
    ['First American Exchange', 37],
    ['Priority Region', 32],
    ['Heritage Escrow Company', 27],
    ['First Title Company', 23],
    ['First Arizona Title Agency', 20],
    ['TRI Pointe Assurance, Inc.', 16],
    ['Title Security Agency, LLC', 12],
    ['First American Abstract of PA', 8],
    ['InterTitle Region', 7],
    ['Arizona Premier Title, LLC', 4],
    ['Titan', 4],
    ['Kaufman Title', 3],
    ['Land Services Title of Texas', 1],
  ]);
  var countByRegionoptions = {
    title: 'Region',
    is3D: true
  };
  var countByRegionPieChart = new google.visualization.PieChart(document.getElementById('countByRegion'));
  countByRegionPieChart.draw(countByRegion, countByRegionoptions);

  var countByRegionBarOptions = {
    title: '',
    width: 800,
    height: 700,
    legend: {
      position: 'none'
    },
    chart: {
      subtitle: '{Date}'
    },
    axes: {
      x: {
        0: {
          side: 'bottom',
          label: 'Region'
        }
      },
      y: {
        0: {
          label: 'Count'
        }
      }
    },
    bar: {
      groupWidth: "30%"
    }
  };
  var countByRegionBarChart = new google.visualization.ColumnChart(document.getElementById('countByRegionBarChart'));
  countByRegionBarChart.draw(countByRegion, countByRegionBarOptions);
}

function DrawPropertyTypeReport() {
  var countByPropertyType = google.visualization.arrayToDataTable([
    ['PropertyType', 'Count'],
    ['Single Family Residence', 5741],
    ['Condominium', 466],
    ['Vacant Land', 368],
    ['Commercial Structure', 234],
    ['TBD', 115],
    ['Other', 97],
    ['Energy Facility', 88],
    ['Planned Unit Development', 63],
    ['Co-op', 61],
    ['Multi Family Residence', 45],
    ['Agricultural Land', 34],
    ['Townhouse', 31],
    ['Retail', 21],
    ['Mobile Home', 20],
    ['Apartment Building', 17],
    ['Industrial', 14],
    ['Manufactured Home', 14],
    ['Office', 9],
    ['Convenience Store/Market', 7],
    ['Hotel/Motel', 7],
    ['Restaurant/Fast Food', 7],
    ['Health Care Facility', 3],
    ['Entertainment/Theatre', 2],
    ['Self Storage', 2],
    ['Timber Land', 1],
    ['Rural/Undeveloped Acreage', 1],
    ['Golf Course', 1],
    ['Government Facility', 1],
    ['Church/Religious Facility', 1],
    ['Educational Facility', 1],
  ]);
  var countByPropertyTypeoptions = {
    title: 'Property Type',
    is3D: true
  };
  var countByPropertyTypechart = new google.visualization.PieChart(document.getElementById('countByPropertyType'));
  countByPropertyTypechart.draw(countByPropertyType, countByPropertyTypeoptions);

  var countByPropertyTypeBarOptions = {
    title: '',
    width: 800,
    height: 700,
    legend: {
      position: 'none'
    },
    chart: {
      subtitle: '{Date}'
    },
    axes: {
      x: {
        0: {
          side: 'bottom',
          label: 'Property Type'
        }
      },
      y: {
        0: {
          label: 'Count'
        }
      }
    },
    bar: {
      groupWidth: "30%"
    }
  };
  var countByPropertyTypeBarChart = new google.visualization.ColumnChart(document.getElementById('countByPropertyTypeBarChart'));
  countByPropertyTypeBarChart.draw(countByPropertyType, countByPropertyTypeBarOptions);
}

function DrawBusSegmentReport() {
  var countByBusinessSegmentType = google.visualization.arrayToDataTable([
    ['BusinessSegmentType', 'Count'],
    ['Residential', 7441],
    ['Commercial', 708],
    ['New Home', 420],
    ['Time Share', 193],
    ['Subdivision', 47],
    ['Exchange', 37],
    ['Default-Residential', 6],
    ['Default-Commercial', 1],
  ]);
  var countByBusinessSegmentTypeoptions = {
    title: 'Business Segment',
    is3D: true
  };
  var countByBusinessSegmentTypechart = new google.visualization.PieChart(document.getElementById('countByBusinessSegmentType'));
  countByBusinessSegmentTypechart.draw(countByBusinessSegmentType, countByBusinessSegmentTypeoptions);

  var countByBusinessSegmentTypeBarOptions = {
    title: '',
    width: 800,
    height: 700,
    legend: {
      position: 'none'
    },
    chart: {
      subtitle: '{Date}'
    },
    axes: {
      x: {
        0: {
          side: 'bottom',
          label: 'Business Segment'
        }
      },
      y: {
        0: {
          label: 'Count'
        }
      }
    },
    bar: {
      groupWidth: "30%"
    }
  };
  var countByBusinessSegmentTypeBarChart = new google.visualization.ColumnChart(document.getElementById('countByBusinessSegmentTypeBarChart'));
  countByBusinessSegmentTypeBarChart.draw(countByBusinessSegmentType, countByBusinessSegmentTypeBarOptions);


};
