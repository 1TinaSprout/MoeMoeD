var app = new Vue({
    el: "#app",
    data: {
        loading: false,
        current: false,
        download: true,
        create_folder: false,
        video: false,
        create_folderName: "",
        search_content: "",
        video_src: "/",
        count: 0,
        transition: ['ease', 'fade'],
        content_columns: [{
            type: 'selection',
            width: 60,
            align: 'center'
        }, {
            title: "文件名",
            key: "Name",
            render: function (h, params) {
                if (params.row.type == "Folder") {
                    return h('div', { attrs: { style: "padding-top:8px" } }, [
                        h('Icon', { attrs: { type: "folder", style: "padding-left:3px;font-size:18px" } }),
                        h('i-button', {
                            attrs: { type: "text", style: "padding-left:10px;padding-top:0px", folderid: params.row.Id },
                            on: { click: inToFolder }
                        }, params.row.Name)
                    ]);
                } else if (params.row.type == "mp4") {
                    return h('div', { attrs: { style: "padding-top:8px" } }, [
                        h('Icon', { attrs: { type: "social-youtube-outline", style: "font-size:18px" } }),
                        h('i-button', {
                            attrs: { type: "text", style: "padding-left:8px;padding-top:0px", mp4id: params.row.Id },
                            on: { click: playVideo }
                        }, params.row.Name)
                    ]);
                } else {
                    return h('div', { attrs: { style: "padding-top:8px" } }, [
                        h('Icon', { attrs: { type: "document-text", style: "padding-left:4px;font-size:18px" } }),
                        h('i-button', {
                            attrs: { type: "text", style: "padding-left:12px;padding-top:0px", fileid: params.row.Id},
                            on: { click: downloadFile }
                        }, params.row.Name)
                    ]);
                }
            }
        }, {
            title: "大小",
            key: "Size"
        }, {
            title: "修改日期",
            key: "UpdateTime"
        }],
        content_data: [{
            Id: 1,
            Name: "我的文件",
            Size: "100K",
            UpdateTime: "2017-01-01",
            type: "Folder"
        }, {
            Id: 2,
            Name: "文件",
            Size: "100K",
            UpdateTime: "2017-01-01",
            type: "File"
        }, {
            Id: 3,
            Name: "我的文件",
            Size: "100K",
            UpdateTime: "2017-01-01",
            type: "mp4"
        }],
        current_data: [],
        navigation: [0]
    },
    methods: {
        select: function (e) {
            app.$Message.info("功能开发中...");
        }, //ok
        createfolder: function (e) {
            isLoading = true;
            if (app.create_folderName == "") {
                app.$Message.info("请输入文件夹名");
            }
            else {
                if (app.navigation[app.navigation.length - 1] == 0) {
                    axios.post("Folder/Add", { Name: app.create_folderName }).then(function (response) {
                        if (response.data.Result == true) {
                            app.content_data.push(response.data.Folder)
                        } else {
                            app.$Message.error("服务器异常，请稍后再试");
                        }
                        app.loading = false;
                    }).catch(function (error) {
                        app.$Message.error("服务器异常，请稍后再试");
                        app.loading = false;
                    })
                } else {
                    axios.post("Folder/Add", { Name: app.create_folderName, FolderId: app.navigation[app.navigation.length - 1] }).then(function (response) {
                        if (response.data.Result == true) {
                            app.$Message.success("服务器异常，请稍后再试");
                        } else {
                            app.$Message.error("服务器异常，请稍后再试");
                        }
                        loading = false;
                    }).catch(function (error) {
                        app.$Message.error("服务器异常，请稍后再试");
                        app.loading = false;
                    })
                }
            }
        }, //ok
        ToChatroom: function (e) {
            location.href = "Chatroom/Index";
        }, //ok
        onSelect: function (selection, row) {
            app.current = true;
            app.current_data.push(row);
        },
        onSelectCancel: function (selection, row) {
            if (app.current_data.length > 0) {
                for (var i in app.current_data) {
                    if (app.current_data[i].Id == row.Id) {
                        app.current_data.splice(i, 1)
                    }
                }
                if (app.current_data.length == 0) {
                    app.current = false
                }
            }
        },
        onSort: function (column, key, order) {

        },
        onSelectAll: function (selection) {
            app.current = true
            app.current_data.splice(0, app.current_data.length);
            app.current_data = selection
            app.isDownLoad(selection)
        },
        onSelectionChange: function (selection) {
            if (selection.length == 0) {
                app.current = false
                app.current_data.splice(0, app.current_data.length);
            }
            app.isDownLoad(selection);
        },
        isDownLoad: function (data) {
            for (var i in data) {
                if (data[i].type == "Folder") {
                    app.download = false
                    return
                }
            }
            app.download = true
        },
        closeVideo: function (e) {
            app.video = false;
            player.src("/")
        },
        onUploadSuccess(response, file, fileList) {
            
        }
    }
})

function playVideo(e) {
    var btn = e.target;
    while (btn.localName != "button") {
        btn = btn.parentElement;
    }
    var mp4id = btn.attributes["mp4id"].value;
    if (mp4id != undefined && mp4id != 0) {
        player.src("/File/GetContent?mp4id=" + mp4id)
        app.video = true;
    }
}

function playVideoById(id) {
    player.src("/File/GetContent?mp4id=" + id)
    app.video = true;
}

function inToFolder(e) {
    var btn = e.target;
    while (btn.localName != "button") {
        btn = btn.parentElement;
    }
    app.$Message.info("进入文件夹")
}

function inToFolderById(folderId) {

}

function downloadFile(e) {
    var btn = e.target;
    while (btn.localName != "button") {
        btn = btn.parentElement;
    }
    app.$Message.info("下载文件")
}

function downloadFileById(fileId) {

}

var player = videojs("myvideo", { fluid: true, autoplay: true }, function () {
})
