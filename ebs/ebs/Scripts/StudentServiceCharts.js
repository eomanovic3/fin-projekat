$(document).ready(function () {
    GetChartBacheleor();
    GetChartMaster();
});

function GetChartBacheleor(tooltipShow) {
    var canvas = document.getElementById('cvsBacheleor');
    var context = canvas.getContext('2d');
    context.clearRect(0, 0, 1500, 700);
    yaxisName = '%'

    $.ajax({
        url: '/Login/GetDataForChartBacheleor',
        type: 'POST',
        cache: false,
        success: function (datos) {
            RGraph.reset(canvas)
            var ytd = eval('[' + datos + ']');
            if (ytd.length > 0) {
                var tooltip1 = ['2013 - <b>' + ytd[0] + '%</b>', '2014 - <b>' + ytd[1] + '%</b>', '2015 - <b>' + ytd[2] + '%</b>', '2016 - <b>' + ytd[3] + '%</b>', '2017 - <b>' + ytd[4] + '%</b>'];
                var line = new RGraph.Line("cvsBacheleor", ytd)
                    .set('labels', ['2013', '2014', '2015', '2016', '2017'])
                    .set('gutter.left', 100)
                    .set('colors', ['#181B1E'])
                    .set('background.barcolor1', '#FFF')
                    .set('background.barcolor2', '#FFF')
                    .set('tickmarks', 'endcircle')
                    .set('linewidth', 3)
                    .set('shadow', true)
                    .set('numxticks', 2)
                    .set('key', ['Number of enrolled students over the years'])
                    .set('key.position', 'gutter')
                    .set('key.interactive', true)
                    .set('shadow.blur', 20)
                    .set('shadow.color', ['#16181a', '#510821'])
                    .set('tickmarks', 'circle')
                    .set('tooltips', tooltip1)
                    .set('scale.zerostart', false)
                    .set('ylabels', false)
                    .set('background.grid.autofit.align', true)
                    .set('text.angle', 90)
                    .set('gutter.bottom', 40)
                    .set('gutter.top', 40)
                    .set('tooltips.hotspot.xonly', true)
                    .draw()
                    .trace();

                var yaxis = new RGraph.Drawing.YAxis('cvsBacheleor', line.gutterLeft)
                    .set('max', line.max)
                    .set('title', 'Bacheleor students')
                    .set('colors', ['black'])
                    .set('gutter.bottom', 55)
                    .set('gutter.top', 40)
                    //.set('max', ymaxValue)
                    //.set('min', yminValue)
                    .draw();
            }
        },
    });
}

function GetChartMaster(tooltipShow) {
    var canvas = document.getElementById('cvsMaster');
    var context = canvas.getContext('2d');
    context.clearRect(0, 0, 1500, 700);
    yaxisName = '%'

    $.ajax({
        url: '/Login/GetDataForChartMaster',
        type: 'POST',
        cache: false,
        success: function (datos) {
            RGraph.reset(canvas)
            var ytd = eval('[' + datos + ']');
            if (ytd.length > 0) {
                var tooltip1 = ['2013 - <b>' + ytd[0] + '%</b>', '2014 - <b>' + ytd[1] + '%</b>', '2015 - <b>' + ytd[2] + '%</b>', '2016 - <b>' + ytd[3] + '%</b>', '2017 - <b>' + ytd[4] + '%</b>'];
                var line = new RGraph.Line("cvsMaster", ytd)
                    .set('labels', ['2013', '2014', '2015', '2016', '2017'])
                    .set('gutter.left', 100)
                    .set('colors', ['#181B1E'])
                    .set('background.barcolor1', '#FFF')
                    .set('background.barcolor2', '#FFF')
                    .set('tickmarks', 'endcircle')
                    .set('linewidth', 3)
                    .set('shadow', true)
                    .set('numxticks', 2)
                    .set('key', ['Number of enrolled students over the years'])
                    .set('key.position', 'gutter')
                    .set('key.interactive', true)
                    .set('shadow.blur', 20)
                    .set('shadow.color', ['#16181a', '#510821'])
                    .set('tickmarks', 'circle')
                    .set('tooltips', tooltip1)
                    .set('scale.zerostart', false)
                    .set('ylabels', false)
                    .set('background.grid.autofit.align', true)
                    .set('text.angle', 90)
                    .set('gutter.bottom', 40)
                    .set('gutter.top', 40)
                    .set('tooltips.hotspot.xonly', true)
                    .draw()
                    .trace();

                var yaxis = new RGraph.Drawing.YAxis('cvsMaster', line.gutterLeft)
                    .set('max', line.max)
                    .set('title', 'Master students')
                    .set('colors', ['black'])
                    .set('gutter.bottom', 55)
                    .set('gutter.top', 40)
                    //.set('max', ymaxValue)
                    //.set('min', yminValue)
                    .draw();
            }
        },
    });
}