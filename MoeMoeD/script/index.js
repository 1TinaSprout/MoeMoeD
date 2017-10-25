var carousel = new Vue({
    el:"#login-carousel",
    data:{
        banner:"index-banner-1",
        number: 1
    },
    methods:{

    }
});
var container = new Vue({
    el: "#login-container",
    data: {
        single: "true",
        value: 0,
        loading:false,
        formValidate: {
            username: "",
            password: ""
        },
        ruleValidate: {
            username: [
                { required: true, message: '姓名不能为空', trigger: 'blur' }
            ],
            password: [
                { required: true, message: '密码不能为空', trigger: 'blur' }
            ]
        }
    },
    methods:{
        Login: function(e){
            this.$refs['formValidate'].validate((valid) => {
                if (valid) {
                    this.loading = true;
                    Vue.http.post("User/Login", {"UserName" : this.username, "Password" : this.password}).then(function(response){
                        if(response.Data.Result != 1)
                        {
                            ErrorModal.modal = true;
                        }
                    },function(e){
                        ErrorModal.modal = true;
                    });
                } else {
                    this.$Message.error('请输入格式正确的账号和密码!');
                }
            })
        },
        clean: function(e){
            this.username = "";
        }
    }
});
var download = new Vue({
    el:"#login-download",
    data:{

    }
});
var footer = new Vue({
    el:"#footer",
    data:{

    }
});

var ErrorModal = new Vue({
    el:"#ErrorModal",
    data:{
        modal:false
    },
    methods:{
        ok: function(){
            container.loading = false;
        },
        cancel: function(){
            container.loading = false;
        }
    }
});

    window.setInterval(function(){
        if(carousel.number == 6){
            carousel.number = 1;
            carousel.banner = "index-banner-" + carousel.number;
        }else{
            carousel.banner = "index-banner-" + carousel.number;
            carousel.number++;
        }
    },6000);

