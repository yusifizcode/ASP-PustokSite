$(document).ready(function () {
    $(".show-detail").click(function (e) {

        let url = $(this).attr('href')

        fetch(url)
            .then(response => response.text())
            .then(data => {

            })

        $("#bookDetailModal").modal('show');


    })
})