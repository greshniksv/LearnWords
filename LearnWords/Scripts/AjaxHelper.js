'use strict';

class Ajax {

    static Post(url, data, onSuccess, onError, onComplete) {
        $.ajax({
            type: "POST",
            url: url,
            processData: false,
            contentType: 'application/json',
            data: data,
            success: onSuccess, //Function( Anything data, String textStatus, jqXHR jqXHR )
            error: onError, // Function( jqXHR jqXHR, String textStatus, String errorThrown )
            complete: onComplete // Function( jqXHR jqXHR, String textStatus )
        });
    }

    static HideLoading() {

    }
}
