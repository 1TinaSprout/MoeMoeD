var app = new Vue({
    el: "#app",
    data: {
        loading: false, //是否有事件执行中
        current: false, //是否有选中的数据
        download: true, //选中数据中是否可以下载（是否含有文件夹）
        create_folder: false, //是否打开新建文件夹对话框
        video: false, //是否显示播放器,
        create_folderName: "", //新建文件夹的名字
        search_content: "", //搜素框的内容
        video_src: "/video_error.mp4", //播放器的src
        count: 0, //当前页的文件总个数
        transition: ['ease', 'fade'], //对话框的动画效果
        content_columns: [{
            type: 'selection',
            width: 60,
            align: 'center'
        }, {
            title: "文件名",
            key: "Name",
            render: function (h, params) {
                if (params.row.Type == "Folder") {
                    return h('div', { attrs: { style: "padding-top:8px" } }, [
                        h('Icon', { attrs: { type: "folder", style: "padding-left:3px;font-size:18px" } }),
                        h('i-button', {
                            attrs: { type: "text", style: "padding-left:10px;padding-top:0px", folderid: params.row.Id , name: params.row.Name},
                            on: { click: inToFolder }
                        }, params.row.Name)
                    ]);
                } else if (params.row.Type == "video/mp4") {
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
                            attrs: { type: "text", style: "padding-left:12px;padding-top:0px", fileid: params.row.Id },
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
        }], //当前页数据的表头
        content_data: [{
            Id: 1,
            Name: "我的文件",
            Size: "100K",
            UpdateTime: "2017-01-01",
            Type: "Folder"
        }, {
            Id: 2,
            Name: "文件",
            Size: "100K",
            UpdateTime: "2017-01-01",
            Type: "File"
        }, {
            Id: 3,
            Name: "我的文件",
            Size: "100K",
            UpdateTime: "2017-01-01",
            Type: "video/mp4"
        }], //当前页数据的内容
        current_data: [], //当前选中的内容
        navigation: [{ FolderId: 0, Name: "全部文件" }]  //导航栏的FolderId的集合
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
                var folderId = app.navigation[app.navigation.length - 1].FolderId
                if (folderId == 0) {
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
                    axios.post("Folder/Add", { Name: app.create_folderName, FolderId: folderId }).then(function (response) {
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
                if (data[i].Type == "Folder") {
                    app.download = false
                    return
                }
            }
            app.download = true
        },
        closeVideo: function (e) {
            app.video = false;
            player.src("/video_error.mp4")
        },
        onUploadSuccess(response, file, fileList) {
            app.$Message.success(file.name + " 上传成功")
        },
        currentDelete: function (e) {
            var idList = new Array();
            for (var i in app.current_data) {
                var data = app.current_data[i]
                idList.push({ Type: data.Type, Id: data.Id })
            }
            axios.post("Home/Delete", { IdList: idList }).then(function (response) {
                if (response.data.Result == true) {
                    for (var i in app.current_data) {
                        var current = app.current_data[i]
                        for (var j in app.content_data) {
                            var content = app.content_data[j]
                            if (current.Id == content.Id && current.Type == content.Type) {
                                app.content_data.splice(j, 1)
                            }
                        }
                    }
                } else {
                    showError(error)
                }
            }).catch(function (error) {
                showError(error)
            })
        },
        toNavigation: function (e) {
            if (e.target.localName == "span") {
                var name = e.target.innerText
                var folderid = e.target.parentElement.attributes["folderid"].value
            } else {
                var name = e.target.children[0].innerText
                var folderid = e.target.attributes["folderid"].value
            }
            
            if (folderid == undefined) {
                showError("未知错误")
            } else {
                inToFolderById(folderid);
            }
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
        var src = "http://" + window.location.host + "/File/GetContent/" + mp4id + "?fileName=video.mp4";
        player.src(src);
        player.play()
        app.video = true;
    }
}

function playVideoById(id) {
    app.video = true;
}

function inToFolder(e) {
    var btn = e.target;
    while (btn.localName != "button") {
        btn = btn.parentElement;
    }
    var folderid = btn.attributes["folderid"].value
    var name = btn.attributes["name"].value
    inToFolderById(folderid, name)
}

function inToFolderById(folderId, name) {
    //清空数据
    app.content_data.splice(0, app.content_data.length)
    app.current_data.splice(0, app.current_data.length)

    var nav = app.navigation;
    for (var i in nav) {
        if (nav[i].FolderId == folderId) {
            if (nav.length - Number(i) - 1 == 0) break;
            var index = Number(i) + 1;
            var col = nav.length - Number(i) - i;
            nav.splice(index, col);
            break;
        }
        if (i == nav.length - 1) {
            nav.push({ FolderId: folderId, Name: name })
        }
    }

    if (folderId == undefined) {
        showError("进入文件夹失败")
    } else if (folderId == 0) {
        //请求数据并赋值
        axios.post("Home/Get").then(function (response) {
            app.content_data = response.data.DataList
        }).catch(function (error) {
            showError(error)
        })
    } else {
        //请求数据并赋值
        axios.post("Home/Get", { FolderId: folderId }).then(function (response) {
            app.content_data = response.data.DataList
        }).catch(function (error) {
            showError(error)
        })
    }

    //页面刷新
    app.current = false
    app.download = false
    app.video = false
}

function downloadFile(e) {
    var btn = e.target;
    var fileName = null;
    if (btn.localName != "button") {
        fileName = btn.innerText;
        btn = btn.parentElement;
    } else {
        fileName = btn.children.innerText;
    }
    var fileid = btn.attributes["fileid"].value;
    if (fileid != undefined && fileid != 0) {
        window.open("http://" + window.location.host + "/File/GetContent/" + fileid + "?fileName=" + fileName)
    }
}

function downloadFileById(fileId, fileName) {
    if (fileid != undefined && fileid != 0) {
        window.open("http://" + window.location.host + "/File/GetContent/" + fileid + "?fileName=" + fileName)
    }
}

var player = videojs("myvideo", { fluid: true, autoplay: true }, function () {
})

function showError(error) {
    app.$Modal.error({
        title: "处理失败",
        content: "服务器异常,请稍后再试",
        onOk: function (e) {
            app.$modal.remove()
            window.location.href = "http://" + window.location.host;
        }
    })
}

window.onload = function () {
    //请求初始数据
    axios.post("Home/Get").then(function (response) {
        app.content_data = response.data.DataList
    }).catch(function (error) {
        showError(error)
    })
}