<template>
    <div id="app-header">
        <div class="headerApp-item">
            <img src="../../assets/images/devfast-logo.png" alt="Logo" height="50px">
            <div class="header-title">Greeting Animal</div>
        </div>
        <div class="headerApp-item">
            <div class="name-user">Hello {{name}}</div>
            <img class="avatar" src="../../assets/images/devfast-logo.png" alt="Logo" height="50" width="50">
        </div>
    </div>
</template>
<script>
    
    export default {
        async beforeMount(){
            this.name= localStorage.getItem('name');
        },
        data(){
            return{
                name: ''
            };
        },
    }
</script>
<style>
    #app-header{
        width: 100%;
        height: 70px;
        display: flex;
        justify-content: space-between;
        background-color: white;
        border-bottom: 1px solid #ccc;
    }
    .headerApp-item{
        width: 240px;
        height: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .header-title{
        color: #007BFF;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 15px;
        font-weight: bold;
        margin-left: 10px;
    }
    .name-user{
        color: #535659;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 15px;
        font-weight: bold;
        margin-right: 10px;
    }
    .avatar{
        border-radius: 25px;
        object-fit: cover;
    }
</style>