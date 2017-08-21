
function searchResult() {
    var search_terms = document.getElementById("search_name").value;
    var data = { "search_terms": search_terms };
    //console.log(JSON.stringify(data));
    $.ajax({
        url: "/Home/Tweets",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (data) {
            //window.location.href = result.Url
            //document.getElementById("searchResult").style.display = "block";
            $('#tweets').html(data);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}