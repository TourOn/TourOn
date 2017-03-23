function showCreateCommentForm() {
    document.getElementById("NewCommentForm").style.display = "block";
    document.getElementById("new-comment").style.display = "none";
}
function hideCreateCommentForm() {
    document.getElementById("NewCommentForm").style.display = "none";
    document.getElementById("new-comment").style.display = "block";
}

$(document).ready(function () {
    $("#like").click(function () {
        $("#ThumbsUp").val("True")
        $("#like").css("border-width", "3px")
        $("#dislike").css("border-width", "1px")
    });
    $("#dislike").click(function () {
        $("#ThumbsUp").val("False")
        $("#dislike").css("border-width", "3px")
        $("#like").css("border-width", "1px")
    });
});