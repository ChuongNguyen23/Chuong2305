$(function () {
    $(".searchDropdown").chosen();
});

$(document).ready(function () {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        language: 'vi',
        autoclose: true,
        todayHighlight: true
    });

    // Lấy múi giờ người dùng
    var timezone = Intl.DateTimeFormat().resolvedOptions().timeZone;
    console.log("User Timezone: " + timezone);
});


$('#btn-one').click(function () {
    html2canvas(document.querySelector('#content')).then((canvas) => {
        let base64image = canvas.toDataURL('image/png');
        // console.log(base64image);
        let pdf = new jsPDF('p', 'px', [1600, 1131]);
        pdf.addImage(base64image, 'PNG', 15, 15, 1110, 360);
        pdf.save('Danh mục sản phẩm.pdf');
    });
});
