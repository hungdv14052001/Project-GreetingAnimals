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
        <div class="control-contairner">
            <div class="control-item">
                <input class="txtControl" type="text" placeholder="User name" v-model="username">
            </div>
            <div class="validation">
                <div id="username-Validation" v-if="isUserName">
                    Enter your username!
                </div>
            </div>
            <div class="control-item">
                <input class="txtControl" type="password" placeholder="Password" v-model="password">
            </div>
            <div class="validation">
                <div id="password-Validation" v-if="isPassword">
                    Enter your password!
                </div>
            </div>
            <button @click="Login" class="btnLogin">Login</button>
            <a class="foget-password" href="#">Foget password?</a>
            <div class="seperation"></div>
            <button class="btnLogin btnRegister">Register</button>
        </div>
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
                isUserName: false,
                isPassword: false,
            };
        },

        methods: {
            
            /// <summary>
            /// User Login
            /// </summary>
            Login(){
                var loginResult= false;
                var username = this.username;
                var password = this.password;
                var idUser=0;
                var resultCheck= true;
                if(username.length==0){
                  this.isUserName= true;
                  resultCheck= false;
                }
                else{
                  this.isUserName= false;
                }
                if(password.length==0){
                  this.isPassword= true;
                  resultCheck= false;
                }
                else{
                  this.isPassword= false;
                }
                if(resultCheck==false){
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
    .login-contairner{
        width: 100%;
        height: 680px;
        display: flex;
        justify-content: center;
        align-items: center;
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
    }
    .control-item{
        display: flex;
        justify-content: center;
        align-items: center;
        border: 1px solid #ccc;
        border-radius: 3px;
        width: 80%;
        margin-left: 10%;
        height: 36px;
        margin-top: 25px;
    }
    .validation{
        position: absolute;
        height: 15px;
        color: #ff0000;
        margin-left: 2%;
    }
    .txtControl{
        outline: none;
        border: none;
        height: 28px;
        width: 90%;
    }
    .btnLogin{
        border-radius: 18px;
        width: 80%;
        margin-left: 10%;
        height: 45px;
        margin-top: 25px;
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
