var conn = $.connection("/connection");

var app = new Vue({
    el: "#app",
    data: {
        userName: "用户名",
        userSign: "个性化签名",
        roomName: "会话窗口名",
        message_content: "",
        work_list: [{
            Id:0,
            name: "111",
            Email: "222"
        }, {
            Id: 1,
            name: "333",
            Email: "444"
        }],
        message_list: []
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

window.onload = function () {
    axios.get("../User/Get").then(function (response) {
        app.userName = response.data.Name;
        app.userSign = response.data.Email;
    }).catch(function (error) {

    })
    axios.get("../Chatroom/Get").then(function (response) {
        app.work_list = response.data;
    }).catch(function (error) {

    })
}

//接受服务器的推送
conn.received(function (data) {
    data = JSON.parse(data);
    var name = data.name;
    var content = data.content;
    if (name == app.userName) {
        app.message_list.push({ type: "oneself", name: "", content: content })
    } else {
        app.message_list.push({ type: "other", name: name, content: content })
    }
});