var conn = null;

var app = new Vue({
    el: "#app",
    data: {
        userName: "用户名",
        userSign: "个性化签名",
        roomName: "会话窗口名",
        message_content: "",
        work_list: [],
        message_list: []
    },
    methods: {
        ToHome: function (e) {
            location.href = '../../';
        },
        click_sendMessage: function (e) {
            conn.start().done(function (data) {
                if (app.message_content != "") {
                    conn.send({ Command = 0, Name: app.userName, Content: app.message_content });//发送给服务器
                    app.message_content = "";
                }
            });
        }
    }
})

window.onload = function () {
    axios.get("../User/Get").then(function (response) {
        app.userName = response.data.User.Name;
        app.userSign = response.data.User.Email;
        conn = $.connection("/connection");

        conn.received(function (data) {
            data = JSON.parse(data);

            if (data.Command == 0) {
                var name = data.Name;
                var content = data.Content;
                if (name == app.userName) {
                    app.message_list.push({ type: "oneself", name: "", content: content })
                } else {
                    app.message_list.push({ type: "other", name: name, content: content })
                }
            } else if (data.Command == 1) {
                app.work_list.push({ Id = data.User.Id, Name = data.User.Name, Email = data.User.Email })
            } else if (data.Command == 2) {
                for (var i in app.work_list) {
                    if (app.work_list[i].Name == data.User.Name) {
                        app.work_list.splice(i, 1)
                    }
                }
            }
        });

        conn.send({ Command = 1 ,Name: app.userName });
        //接受服务器的推送
        
    }).catch(function (error) {

    })
}

window.onbeforeunload = function () {
    conn.send({ Command = 2, Name: app.userName, Content: app.message_content });
}


