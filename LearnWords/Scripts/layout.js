'use strict';

class Layout {

    static ShowLoading() {
        $(".wait-overlay").fadeIn(500);
    }

    static HideLoading() {
        $(".wait-overlay").fadeOut(500);
    }
}
