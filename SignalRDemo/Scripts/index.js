$(function () {

    var hub = $.connection.simpleHub;
//    $.connection.hub.start().done(function() {
//        hub.server.connected();
    //    });

    $.connection.hub.start();

    $("#send-message").on('click', function() {
        hub.server.newMessage($("#name").val(), $("#message").val());
        $("#message").val('');
    });

    hub.client.newMessagePosted = function(message) {
        $("#chat-area").append(`${message.Name}: ${message.Message} \r\n`);
    }

    hub.client.newConnection = function(msg) {
        $("#chat-area").append(msg + "\r\n");
    }


});