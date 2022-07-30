<template>
    <div id="player-list">
        <div class="player-list-title">
            Admin
        </div>
        <div class="player-list-main">
            <div @click="showSearch" class="search-title">
                <i class="icon-text">{{iconSearch}}</i>
                Searching criteria
            </div>
            <div v-if="isSearch" class="search-container">
                <div class="row row-label">
                    <div class="col">
                        Name
                    </div>
                    <div class="col">
                        Email
                    </div>
                </div>
                <div class="row row-control">
                    <div class="col">
                        <div class="control-contairner">
                            <div class="iconcontrol">
                                <div class="icon-item"></div>
                            </div>
                            <div class="txt-contairner">
                                <input class="txt-control" type="text" placeholder="Name" v-model="keyName" />
                            </div>
                        </div>
                    </div>
                    <div class="col">
                        <div class="control-contairner">
                            <div class="iconcontrol">
                                <div class="icon-item"></div>
                            </div>
                            <div class="txt-contairner">
                                <input class="txt-control" type="text" placeholder="Email" v-model="keyEmail" />
                            </div>
                        </div>
                    </div>
                    <div class="col">
                        <div class="control-contairner">
                            <button @click="search" class="btnSearch">Search</button>
                            <button @click="clear" class="btnClear">Clear</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="list-container">
                <div class="row row-header-list">
                    <div class="col">
                        <div class="control-contairner justify-left">
                            total: {{total}} Admin
                            <button class="btn-tranfer"><<</button>
                            <button class="btn-tranfer"><</button>
                            <div class="current-Page">1</div>
                            <button class="btn-tranfer">></button>
                            <button class="btn-tranfer">>></button>
                        </div>
                    </div>
                    <div class="col">
                        <div class="control-contairner justify-right">
                            <NuxtLink class="btnSearch" :to="{ name: 'adminCreateEditPage', params: { id: '0'}}">Add</NuxtLink>
                            <button @click="refresh" class="btnClear">Refresh</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="list-container">
                <div class="list-row">
                    <div class="col-id title-list">
                        Id
                    </div>
                    <div class="col-name title-list">
                        Name
                    </div>
                    <div class="col-email title-list">
                        Email
                    </div>
                    <div class="col-birth title-list">
                        Birth day
                    </div>
                    <div class="col-phone title-list">
                        Num phone
                    </div>
                    <div class="col-address title-list">
                        address
                    </div>
                    <div class="col-action title-list">
                        action
                    </div>
                </div>
                <div :style="getBackGround(index)" v-for="(admin, index) in adminListDisPlay" class="list-row">
                    <div class="col-id title-list">
                        {{admin.id}}
                    </div>
                    <div class="col-name text-email">
                        {{admin.name}}
                    </div>
                    <div class="col-email">
                        {{admin.email}}
                    </div>
                    <div class="col-birth">
                        {{admin.dateofbirth.slice(0,-9)}}
                    </div>
                    <div class="col-phone">
                        {{admin.numPhone}}
                    </div>
                    <div class="col-address">
                        {{admin.address}}
                    </div>
                    <div class="col-action">
                        <NuxtLink class="btnEdit" :to="{ name: 'adminCreateEditPage', params: { id: admin.id}}">Edit</NuxtLink>
                        <button @click="confirmDelete(admin.id)" class="btnDelete">Delete</button>
                    </div>
                </div>
            </div>    
        </div>
    </div>
</template>
<script>
    import { adminAPI, dellObject } from "../../assets/js/main.js";
    export default {

        /// <summary>
        /// get list admin in api
        /// </summary>
        /// <returns></returns>
        async beforeMount(){
            this.adminList= await fetch(adminAPI)
                .then((res)=>res.json());
            this.adminListDisPlay= this.adminList;
            this.total= this.adminList.length;
        },

        data(){
            return{
                adminList: [],
                adminListDisPlay: [],
                backEven:{
                    backgroundColor:"#F6F6F6" 
                },
                backOdd:{
                    backgroundColor:"#ffffff" 
                },
                keyName: '',
                keyEmail: '',
                isSearch: true,
                iconSearch: '▼',
                total: 0,
            };
        },

        methods: {

            /// <summary>
            /// get back ground color for row Admin
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            getBackGround(index){
                if(index%2==0){
                    return this.backEven;
                }
                else{
                    return this.backOdd;
                }
            },

            /// <summary>
            /// display form search
            /// </summary>
            /// <returns></returns>
            showSearch(){
                var isSearch= this.isSearch;
                if(isSearch){
                    this.isSearch= false;
                    this.iconSearch= '▲';
                }
                else{
                    this.isSearch= true;
                    this.iconSearch= '▼';
                }
            },

            /// <summary>
            /// search Admin
            /// </summary>
            /// <returns></returns>
            search(){
                var keyName=this.keyName;
                var keyEmail= this.keyEmail;
                if(keyName.length==0){
                    this.adminListDisPlay= this.adminList.filter(function(admin){
                        return admin.email.toLowerCase().includes(keyEmail.toLowerCase());
                    })
                }
                else if(keyEmail.length==0){
                    this.adminListDisPlay= this.adminList.filter(function(admin){
                        return admin.name.toLowerCase().includes(keyName.toLowerCase());
                    })
                }
                else{
                    this.adminListDisPlay= this.adminList.filter(function(admin){
                        return admin.name.toLowerCase().includes(keyName.toLowerCase())&&admin.email.toLowerCase().includes(keyEmail.toLowerCase());
                    })
                }
            },

            /// <summary>
            /// refresh list
            /// </summary>
            /// <returns></returns>
            refresh(){
                this.adminListDisPlay= this.adminList;
            },

            /// <summary>
            /// clearch control searchs
            /// </summary>
            /// <returns></returns>
            clear(){
                this.keyName = '';
                this.keyEmail = '';
            },

            /// <summary>
            /// confirm delete Admin 
            /// </summary>
            /// <param name="id"></param>
            /// <returns>response.json()</returns>
            confirmDelete(id) {
                if (confirm('Do you want to delete this Admin?')) {
                    dellObject(id, adminAPI);
                } else {
                    alert("Cancelled");
                }
            },
            dellObject,
        }
    }

</script>
<style>
    .player-list-title{
        height: 45px;
        width: 100%;
        padding: 0 30px;
        color: #007BFF;
        display: flex;
        align-items: center;
        font-weight: bold;
        border-bottom: 1px solid #ccc;
    }
    .player-list-main{
        width: 100%;
        min-height: 590px;
        background-color: #f0f0f0;
    }
    .search-title{
        height: 45px;
        width: 100%;
        padding: 0 30px;
        display: flex;
        align-items: center;
        font-weight: bold;
        font-size: 23px;
        cursor: pointer;
    }
    .icon-text{
        margin-right: 7px;
        color: #007BFF;
    }
    .row-label{
        height: 30px;
        width: 60%;
        padding: 0 30px;
        display: flex;
        align-items: center;
    }
    .row-control{
        min-height: 34px;
        width: calc(90% - 30px);
        padding: 0 30px;
        display: flex;
        align-items: center;
        margin-bottom: 20px;
    }
    .control-contairner{
        height: 34px;
        display: flex;
        margin-bottom: 10px;
    }
    .icon-item{
        width: 15px;
        height: 15px;
        background-color: #495057;
    }
    .iconcontrol{
        height: 34px;
        width: 40px;
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: white; 
        border: 1px solid #ccc;
    }
    .txt-contairner{
        height: 34px;
        width: 280px;
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: white; 
        border: 1px solid #ccc;
    }
    .txt-control{
        height: 32px;
        width: 100%;
        padding: 0 15px;
        outline: none;
        border: none;
    }
    .btnSearch{
        background-color: #007BFF;
        color: white;
        border: none;
        border-radius: 3px;
        height: 34px;
        padding: 0 20px;
        margin-right: 30px;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .btnSearch:hover{
        text-decoration: none;
        color: white;
    }
    .btnClear{
        background-color: white;
        color: #007BFF;
        border: 1px solid #007BFF;
        border-radius: 3px;
        height: 34px;
        padding: 0 20px;
    }
    .row-header-list{
        height: 34px;
        width: calc(100% + 30px);
        padding: 0 30px;
        display: flex;
        align-items: center;
        margin-bottom: 20px;
    }
    .justify-right{
        justify-content: right;
    }
    .justify-left{
        justify-content: left;
        align-items: center;
    }
    .btn-tranfer{
        height: 30px;
        width: 30px;
        background-color: white;
        border: 1px solid #ccc;
        border-radius: 50%;
        margin-left: 5px;
        color: #ccc;
        font-size: 13px;
        font-weight: bold;
    }
    .current-Page{
        height: 30px;
        width: 30px;
        background-color: #007BFF;
        border: 1px solid #ccc;
        border-radius: 50%;
        margin-left: 5px;
        color: white;
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: 13px;
    }
    .list-row{
        height: 40px;
        width: 1229px;
        display: flex;
        margin-left: 30px;
        background-color: white;
        border: 1px solid #ccc;
    }
    .col-id{
        width: 5%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
        padding: 0 10px;
    }
    .col-name{
        width: 20%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-email{
        width: 20%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .text-email{
        color: #007BFF;
    }
    .col-birth{
        width: 11%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-phone{
        width: 14%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-address{
        width: 20%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-action{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .title-list{
        font-weight: bold;
    }
    .btnEdit{
        border: 1px solid #007BFF;
        color: #007BFF;
        padding: 1px 5px;
        margin-right: 10px;
        border-radius: 3px;
    }
    .btnDelete{
        border: 1px solid red;
        color: red;
        padding: 1px 5px;
        border-radius: 3px;
    }
</style>