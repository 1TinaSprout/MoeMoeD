var app = new Vue({
    el : "#app",
    data: {
        create_folderName: "",
        search_content: "",
        create_folder: false,
        video: true,
        count:0,
        content_columns: [{
            title: "文件名",
            key:"Name"
        }, {
            title: "大小",
            key:"Size"
        }, {
            title: "修改日期",
            key:"UpdateTime"
        }],
        content_data: [{
            Name: "我的文件",
            Size: "100K",
            UpdateTime: "2017-01-01"
        }]
    },
    methods : {
        select: function (e) {

        },
        createfolder: function (e) {

        },
        ToChatroom: function (e) {
            location.href = "../../Chatroom/Index";
        }
    }
})