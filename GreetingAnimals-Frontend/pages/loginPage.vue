<template>
    <div id="login-page">
        <div class="login-page-contairner">
            <AdminLogin></AdminLogin>
        </div>
        <div class="app-footer text-white">
            Copyright © 2021 DevFast
        </div>
    </div>
</template>

<script>
    import AdminLogin from '../components/Admin/AdminLogin.Vue';
    export default {
        layout: 'login',
        components: { 
            AdminLogin
        },
        name: 'loginPage',
        async beforeMount(){
            
        },
        data(){
            return{
                
            };
        },
        methods: {
            
        }
    }
</script>
<style>
    .login-page-contairner{
        width: 100%;
        min-height: 688px;
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: #f0f0f0;
    }
    .app-footer{
        width: 100%;
        height: 65px;
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: 17px;
        font-family: Arial, Helvetica, sans-serif;
        background-color: #303030;
    }
</style>
