var app = new Vue({
    el: "#app",
    data: {
        is_loading: false,
        is_current: false,
        is_download: true,
        create_folder: false,
        video: false,
        create_folderName: "",
        search_content: "",
        video_src: "",
        count: 0,
        transition: ['ease', 'fade'],
        content_columns: [{
            type: 'selection',
            width: 60,
            align: 'center'
            },{
            title: "文件名",
            key: "Name",
            render: function (h, params) {
                if (params.row.type == "Folder") {
                    return h('div', [
                        h('Icon', { attrs: { type: "folder", style: "padding-left:3px;font-size:18px" } }),
                        h('i-button', { attrs: { type: "text", style: "padding-left:10px;padding-top:0px" } }, params.row.Name)
                    ]);
                } else if (params.row.type == "video/mp4") {
                    return h('div', [
                        h('Icon', { attrs: { type: "social-youtube-outline", style: "font-size:18px" } }),
                        h('i-button', {
                            attrs: { type: "text", style: "padding-left:8px;padding-top:0px" },
                            on: {
                                click: function () {
                                    app.$Message.info("开始播放视频")
                                }
                            }
                        }, params.row.Name)
                    ]);
                } else {
                    return h('div', [
                        h('Icon', { attrs: { type: "document-text", style: "padding-left:4px;font-size:18px" } }),
                        h('i-button', {
                            attrs: { type: "text", style: "padding-left:12px;padding-top:0px" }
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
            type: "video/mp4"
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
                        app.is_loading = false;
                    }).catch(function (error) {
                        app.$Message.error("服务器异常，请稍后再试");
                        app.is_loading = false;
                    })
                } else {
                    axios.post("Folder/Add", { Name: app.create_folderName, FolderId: app.navigation[app.navigation.length - 1] }).then(function (response) {
                        if (response.data.Result == true) {
                            app.$Message.success("服务器异常，请稍后再试");
                        } else {
                            app.$Message.error("服务器异常，请稍后再试");
                        }
                        is_loading = false;
                    }).catch(function (error) {
                        app.$Message.error("服务器异常，请稍后再试");
                        app.is_loading = false;
                    })
                }
            }
        }, //ok
        ToChatroom: function (e) {
            location.href = "Chatroom/Index";
        }, //ok
        onSelect: function (selection, row) {
            if (row.type == "Folder") {
                app.$Message.info("文件夹：" + row.Name + "被选中")
            } else if (row.type == "video/mp4") {
                app.$Message.info("视频：" + row.Name + "被选中")
            } else {
                app.$Message.info("文件：" + row.Name + "被选中")
            }
            app.is_current = true;
            app.current_data.push(row);
            app.$Message.info("当前选中" + row.Name)
        },
        onSelectCancel: function (selection, row) {
            if (app.current_data.length > 0) {
                for (var i in app.current_data) {
                    if (app.current_data[i].Id == row.Id) {
                        app.current_data.splice(i, 1)
                    }
                }
                if (app.current_data.length == 0) {
                    app.is_current = false
                }
            }
        },
        onSort: function (column, key, order) {

        },
        onSelectAll: function (selection) {
            app.is_current = true
            app.current_data.splice(0, app.current_data.length);
            app.current_data = selection
            app.isDownLoad(selection)
        },
        onSelectionChange: function (selection) {
            if (selection.length == 0) {
                app.is_current = false
                app.current_data.splice(0, app.current_data.length);
            }
            app.isDownLoad(selection);
        },
        isDownLoad: function (data) {
            for (var i in data) {
                if (data[i].type == "Folder") {
                    app.is_download = false
                    return
                }
            }
            app.is_download = true
        },
        inFolder: function (e) {

        }
    }
})