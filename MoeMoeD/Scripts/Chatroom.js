var app = new Vue({
    el: "#app",
    data: {
        userName: "用户名",
        userSign: "个性化签名",
        roomName: "会话窗口名",
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
            content:"1111111111"
        }]
    },
    methods: {
        ToHome: function (e) {
            location.href = '../../';
        }
    }
})