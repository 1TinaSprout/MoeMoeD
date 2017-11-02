var conn = $.connection("/connection");

var app = new Vue({
    el: "#app",
    data: {
        userName: "用户名",
        userSign: "个性化签名",
        roomName: "会话窗口名",
        message_content:"",
        work_list: [{
            name: "111",
            nickName: "222"
        }, {
            name: "333",
            nickName: "444"
        }],
        message_list: [{
            type: "other",
            name: "111",
            content: "11111111111"
        }, {
            type: "oneself",
            name: "",
            content: "1111111111"
        }]
    },
    methods: {
        ToHome: function (e) {
            location.href = '../../';
        },
        click_sendMessage: function (e) {
            conn.start().done(function (data) {
                if (app.message_content != "") {
                    conn.send({ name: app.userName, content: app.message_content });//发送给服务器
                    app.message_content = "";
                }
            });
        }
    }
})

window.onload = {

}

//接受服务器的推送
conn.received(function (data) {
    data = JSON.parse(data);
    var name = data.name;
    var content = data.content;
    if (name == app.userName) {
        app.message_list.push({ type: "oneself", name: "", content: data.content })
    } else {
        app.message_list.push({ type: "other", name: name, content: content })
    }
});