<template>
    <div id="admin-list">
        <div class="admin-list-title">
            Player
        </div>
        <div class="admin-list-main">
            <div @click="showSearch" class="search-title">
                <i class="icon-text">{{iconSearch}}</i>
                Searching criteria
            </div>
            <b-form class="search-container" v-if="isSearch">
                <div class="row row-control">
                    <b-form-group label="Name:" label-for="input-name" class="col">
                        <div class="control-contairner">
                            <div class="iconcontrol">
                                <div class="icon-item"></div>
                            </div>
                            <div class="txt-contairner">
                                <b-form-input id="input-name" placeholder="Enter name" class="txt-control" v-model="keyName"></b-form-input>
                            </div>
                        </div>
                    </b-form-group>
                    <b-form-group label="Tag:" label-for="input-email" class="col">
                        <div class="control-contairner">
                            <div class="iconcontrol">
                                <div class="icon-item"></div>
                            </div>
                            <div class="txt-contairner">
                                <b-form-input id="input-email" class="txt-control" placeholder="Enter email" v-model="keyTag"></b-form-input>
                            </div>
                        </div>
                    </b-form-group>
                    <b-form-group class="col">
                        <div class="button-search-contairner">
                            <b-button @click="search" class="btnSearch">Search</b-button>
                            <b-button @click="clear" class="btnClear">Clear</b-button>
                        </div>
                    </b-form-group>
                </div>
            </b-form>
            <!--
            <div v-if="isSearch" class="search-container">
                <div class="row row-label">
                    <div class="col">
                        Name
                    </div>
                    <div class="col">
                        Tag
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
                                <input class="txt-control" type="text" placeholder="Tag" v-model="keyTag" />
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
            -->
            <div class="list-container">
                <div class="row row-header-list">
                    <div class="col">
                        <div class="control-contairner justify-left">
                            total: {{total}} Player
                            <button class="btn-tranfer"><<</button>
                            <button class="btn-tranfer"><</button>
                            <div class="current-Page">1</div>
                            <button class="btn-tranfer">></button>
                            <button class="btn-tranfer">>></button>
                        </div>
                    </div>
                    <div class="col">
                        <div class="control-contairner justify-right">
                            <button class="btnClear">Refresh</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="list-container">
                <div class="list-row">
                    <div class="col-idPlayer title-list">
                        Id
                    </div>
                    <div class="col-namePlayer title-list">
                        Name
                    </div>
                    <div class="col-tagPlayer title-list">
                        Tag
                    </div>
                    <div class="col-levelPlayer title-list">
                        Level
                    </div>
                    <div class="col-rankPlayer title-list">
                        Rank
                    </div>
                    <div class="col-goldPlayer title-list">
                        Gold
                    </div>
                    <div class="col-diamondPlayer title-list">
                        Diamond
                    </div>
                    <div class="col-birthPlayer title-list">
                        Birth day
                    </div>
                    <div class="col-phonePlayer title-list">
                        Num phone
                    </div>
                    <div class="col-addressPlayer title-list">
                        address
                    </div>
                    <div class="col-actionPlayer title-list">
                        action
                    </div>
                </div>
                <div :style="getBackGround(index)" v-for="(player, index) in playerListDisPlay" class="list-row">
                    <div class="col-idPlayer title-list">
                        {{player.id}}
                    </div>
                    <div class="col-namePlayer text-email">
                        {{player.name}}
                    </div>
                    <div class="col-tagPlayer">
                        {{player.tag}}
                    </div>
                    <div class="col-levelPlayer">
                        {{player.level}}
                    </div>
                    <div class="col-rankPlayer">
                        {{player.rank}}
                    </div>
                    <div class="col-goldPlayer">
                        {{player.gold}}
                    </div>
                    <div class="col-diamondPlayer">
                        {{player.diamond}}
                    </div>
                    <div class="col-birthPlayer">
                        {{player.dateofbirth.slice(0,-9)}}
                    </div>
                    <div class="col-phonePlayer">
                        {{player.numPhone}}
                    </div>
                    <div class="col-addressPlayer">
                        {{player.address}}
                    </div>
                    <div class="col-actionPlayer">
                        <NuxtLink class="btnEdit" :to="{ name: 'playerCreateEditPage', params: { id: player.id}}">Detail</NuxtLink>
                        <button class="btnDelete">Lock</button>
                        <NuxtLink class="btnItem" :to="{ name: 'itemListPage', params: { id: player.id}}">Items</NuxtLink>
                    </div>
                </div>
            </div>    
        </div>
    </div>
</template>
<script>
    import { playerAPI } from "../../assets/js/main.js";
    export default {

        /// <summary>
        /// get list admin in api
        /// </summary>
        /// <returns></returns>
        async beforeMount(){
            this.playerList= await fetch(playerAPI)
                .then((res)=>res.json());
            this.playerListDisPlay= this.playerList;
            this.total= this.playerListDisPlay.length;  
        },

        data(){
            return{
                playerList: [],
                playerListDisPlay: [],
                backEven:{
                    backgroundColor:"#F6F6F6" 
                },
                backOdd:{
                    backgroundColor:"#ffffff" 
                },
                keyName: '',
                keyTag: '',
                isSearch: true,
                iconSearch: '▼',
                total: 0,
            };
        },

        methods: {

            /// <summary>
            /// get back ground color for row Player
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
            /// search Player
            /// </summary>
            /// <returns></returns>
            search(){
                var keyName=this.keyName;
                var keyTag= this.keyTag;
                if(keyName.length==0&&keyTag.length!=0){
                    this.playerListDisPlay= this.playerList.filter(function(player){
                        return player.tag==keyTag;
                    })
                }
                else if(keyTag.length==0&&keyName.length!=0){
                    this.playerListDisPlay= this.playerList.filter(function(player){
                        return player.name.toLowerCase().includes(keyName.toLowerCase());
                    })
                }
                else if(keyTag.length==0&&keyName.length==0){
                    this.playerListDisPlay= this.playerList;
                }
                else{
                    this.playerListDisPlay= this.playerList.filter(function(player){
                        return player.name.toLowerCase().includes(keyName.toLowerCase())&&player.tag==keyTag;
                    })
                }
            },

            /// <summary>
            /// clearch input searchs
            /// </summary>
            /// <returns></returns>
            clear(){
                this.keyName = '';
                this.keyTag = '';
            },

            /// <summary>
            /// refresh list
            /// </summary>
            /// <returns></returns>
            refresh(){
                this.adminListDisPlay= this.adminList;
            },

        }
    }

</script>
<style>
    .admin-list-title{
        height: 45px;
        width: 100%;
        padding: 0 30px;
        color: #007BFF;
        display: flex;
        align-items: center;
        font-weight: bold;
        border-bottom: 1px solid #ccc;
    }
    .admin-list-main{
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
    .col-idPlayer{
        width: 4%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
        padding: 0 10px;
    }
    .col-namePlayer{
        width: 14%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-tagPlayer{
        width: 7%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-levelPlayer{
        width: 5%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-rankPlayer{
        width: 5%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-goldPlayer{
        width: 7%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-diamondPlayer{
        width: 7%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .text-emailPlayer{
        color: #007BFF;
    }
    .col-birthPlayer{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-phonePlayer{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-addressPlayer{
        width: 15%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-actionPlayer{
        width: 15%;
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
        margin-right: 10px;
    }
    .btnItem{
        border: 1px solid #0BC151;
        color: #0BC151;
        padding: 1px 5px;
        margin-right: 10px;
        border-radius: 3px;
    }
</style>