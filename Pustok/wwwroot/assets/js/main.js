$(document).ready(function () {
    $(".show-detail").click(function (e) {

        let url = $(this).attr('href')

        fetch(url)
            .then(response => {
                console.log(url)
                if (!response.ok) {
                    alert("Error");
                    return;
                }
                return response.text();
            })
            .then(data => {
                if (data) {
                    $("#bookDetailModal .modal-content").html(data);
                    $("#bookDetailModal").modal('show');
                }
            })


    })
})