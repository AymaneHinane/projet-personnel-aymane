// This is a manifest file that'll be compiled into application.js.
//
// Any JavaScript file within this directory can be referenced here using a relative path.
//
// You're free to add application-wide JavaScript to this file, but it's generally better
// to create separate JavaScript files as needed.
//
//= require jquery-2.2.0.min
//= require bootstrap
//= require_tree .
//= require_self

if (typeof jQuery !== 'undefined') {
    (function($) {
        $(document).ajaxStart(function() {
            $('#spinner').fadeIn();
        }).ajaxStop(function() {
            $('#spinner').fadeOut();
        });
    })(jQuery);
}



$(document).ready(function() {
    // Hide all content elements initially
    $(".content").hide();

    $(".parcours").click(function() {
        var parcoursId = $(this).data("parcours-id");

        // Hide all content elements before showing the selected one
        $(".content").hide();

        // Show the content element with the matching parcoursId
        $(".content[data-parcours-id='" + parcoursId + "']").show();
    });
});

var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function() {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.display === "block") {
            content.style.display = "none";
        } else {
            content.style.display = "block";
        }
    });
}



    $(document).ready(function() {
    $(".img-container img").each(function() {
        // Get the data-image-src attribute value
        var imageUrl = $(this).data("image-src");

        // Set the src attribute to start loading the image
        $(this).attr("src", imageUrl);
    });
});

