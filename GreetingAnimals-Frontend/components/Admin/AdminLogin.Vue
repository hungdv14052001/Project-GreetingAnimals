<template>
    <div @keydown.enter="Login" id="admin-login">
        <div class="introduce-contairner">
            <img class="img-logo" src="../../assets/images/devfast-logo.png" alt="Logo">
            <div class="introduce-content">
                <div class="devfast red">
                    DevFast
                </div>
                <div>
                    Done in the most
                </div>
                <div class="parent">
                    <div class="red">PROFICIENT </div> way.
                </div>
            </div>
        </div>
        <b-form class="control-contairner" @submit="Login">
            <b-form-group>
                <b-form-input
                v-model="username"
                type="email"
                placeholder="Enter email"
                required
                class="txtControl"
                v-bind:class="{'is-invalid': errors.name}"
                v-validate="'required|alpha'"
                ></b-form-input>
                <div class="validation">{{errors.name}}</div>
            </b-form-group>
            <b-form-group>
                <b-form-input
                v-model="password"
                type="password"
                placeholder="Enter password"
                required
                class="txtControl"
                v-bind:class="{'is-invalid': errors.password}"
                v-validate="'required|alpha'"
                ></b-form-input>
                <div class="validation">{{errors.password}}</div>
            </b-form-group>
            <b-button @click="Login" class="btnLogin" >Login</b-button>
            <a class="foget-password" href="#">Foget password?</a>
            <div class="seperation"></div>
            <b-button class="btnRegister" >Register</b-button>
        </b-form>
    </div>
</template>

<script>
    const apiLogin= 'https://localhost:44346/api/Login/AdminLogin';
    export default {
        components: { 
        
        },
        async beforeMount(){
            
        },

        data(){
            return{
                username: '',
                password: '',
                errors:{
                    username: '',
                    password: '',
                }
            };
        },

        methods: {
            
            /// <summary>
            /// User Login
            /// </summary>
            Login(){
                var resultValid = this.validate();
                if(!resultValid){
                    return;
                }
                var account={
                    userName: this.username,
                    password: this.password
                }
                this.postData(apiLogin, account)
                    .then(data=>{
                        if(data.admin!=null){
                            localStorage.setItem('id', data.admin.id);
                            localStorage.setItem('name', data.admin.name);
                            localStorage.setItem('token', data.token);
                            this.$router.push('adminListPage');
                        }
                        else{
                            alert("Username or password is incorrect");
                        }
                    });
            },

            validate(){
                this.errors={
                    username: '',
                    password: '',
                }
                var result= true;
                if(!this.username){
                    this.errors.name='Enter email!';
                    result= false;
                }
                if(!this.username.includes('@')&&!this.username.includes('.')){
                    this.errors.name='Username must be email!';
                    result= false;
                }
                if(!this.password){
                    this.errors.password='Enter password!';
                    result= false;
                }
                return result;
            },

            /// <summary>
            /// post data into API
            /// </summary>
            /// <param name="url"></param>
            /// <param name="data"></param>
            /// <returns>response.json()</returns>
            async postData(url = '', data = {}) {
                const response = await fetch(url, {
                    method: 'POST',
                    headers: {
                    'Content-Type': 'application/json'
                    },
                    redirect: 'follow', 
                    referrerPolicy: 'no-referrer', 
                    body: JSON.stringify(data) 
                });
                return response.json(); 
            }
        }
    }
</script>
<style>
    #admin-login{
        display: flex;
    }
    .red{
        color: #ff0000;
        margin-right: 5px;
    }
    .parent{
        display: flex;
    }
    .introduce-contairner{
        height: 400px;
        width: 400px;
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: 25px;
        margin-top: -150px;
    }
    .img-logo{
        height: 100px;
        margin-right: 10px;
    }
    .introduce-content{
        width: 300px;
        font-family: Arial, Helvetica, sans-serif;
        font-weight: bold;
    }
    .devfast{
        font-size: 35px;
    }
    .control-contairner{
        height: 360px;
        width: 340px;
        background-color: #fff;
        border-radius: 3px;
        margin-top: -40px;
        padding-top: 35px;
    }
    .validation{
        position: absolute;
        color: #ff0000;
        margin-left: 35px;
        margin-top: -10px;
    }
    .txtControl{
        outline: none;
        height: 34px;
        width: 80%;
        margin-left: 10%;
        margin-bottom: 10px;
    }
    .btnLogin{
        border-radius: 18px;
        width: 80%;
        margin-left: 10%;
        height: 45px;
        margin-top: 10px;
        background-color: #303030;
        color: #ff0000;
        font-size: 21px;
        font-weight: bold;
        font-family: Arial, Helvetica, sans-serif;
    }
    
    .foget-password{
        width: 80%;
        margin-left: 10%;
        height: 36px;
        margin-top: 15px;
        text-decoration: none;
        display: flex;
        justify-content: center;
    }
    .btnRegister{
        color: #fff;
        border-radius: 18px;
        width: 80%;
        margin-left: 10%;
        height: 45px;
        margin-top: 25px;
        background-color: #303030;
        font-size: 21px;
        font-weight: bold;
        font-family: Arial, Helvetica, sans-serif;
    }
    .login-footer{
        width: 100%;
        height: 70px;
        display: flex;
        justify-content: center;
        align-items: center;
        color: #fff;
        font-size: 17px;
        font-family: Arial, Helvetica, sans-serif;
        background-color: #303030;
    }
    .seperation{
        width: 80%;
        margin-left: 10%;
        height: 1px;
        border-bottom: 1px solid #ccc;
    }
</style>

