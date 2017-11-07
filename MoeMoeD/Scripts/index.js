var app = new Vue({
    el: "#app",
    data: {
        single: "true",
        modal: false,
        value: 0,
        bg : 1,
        loading:false,
        formValidate: {
            username: "",
            password: ""
        },
        ruleValidate: {
            username: [
                { required: true, message: '用户名不能为空', trigger: 'blur' }
            ],
            password: [
                { required: true, message: '密码不能为空', trigger: 'blur' }
            ]
        }
    },
    methods:{
        Login: function (e) {
            var isValid = false;
            this.$refs['formValidate'].validate(function (valid) {
                isValid = valid;
            })
            if (isValid) {
                this.loading = true;
                axios.post("Home/Login", { "Name": this.username, "Password": this.password }).then(function (response) {
                    if (response.Data.Result != true) {
                        this.$Message.error('用户名或密码错误!');
                    }
                }).catch(function (e) {
                    app.modal = true;
                });
            } else {
                this.$Message.error('请输入格式正确的账号和密码!');
            }
        },
        clean: function(e){
            app.username = "";
        },
        ok: function () {
            app.loading = false;
        },
        cancel: function () {
            app.loading = false;
        }
    }
});

window.setInterval(function () {
    if (app.bg == 5) {
        app.bg = 1;
    } else {
        app.bg++;
    }
},8000);

