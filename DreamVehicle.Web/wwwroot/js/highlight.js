var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }

    return false;
};


(function() {
    var searched = getUrlParameter('Searched');
    $("[data-description]").each(function(index, element) {
        $(element).html(element.innerHTML.replace(new RegExp(searched, 'g'), '<span class="highlight">' + searched + '</span>'));
    });
})();