(function (modules, $) { 

    "use strict";

    var setup = {
        hubName: function () { },
        callback: function () { },
        callbackName: function () { },
        onStart: function (){},
        onFail: function (){}
    }

    modules.NotificationHub = (function (cfgSetup) {

        $.extend(setup, cfgSetup);

        var connection = $.connection;
        var hubInstance = connection[setup.hubName];

        hubInstance.client[setup.callbackName] = setup.callback;

        connection.hub.start()
            .done(setup.onStart)
            .fail(setup.fail);

        this.send = function (message) {
            var callback = hubInstance.server[setup.callbackName];
            callback(message);
        };

    });

})(window, jQuery);