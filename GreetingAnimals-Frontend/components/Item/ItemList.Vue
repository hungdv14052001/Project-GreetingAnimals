<template>
    <div id="player-list">
        <div class="player-list-title">
            Item
        </div>
        <div class="player-list-main">
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
                    <b-form-group label="Id player:" label-for="input-email" class="col">
                        <div class="control-contairner">
                            <div class="iconcontrol">
                                <div class="icon-item"></div>
                            </div>
                            <div class="txt-contairner">
                                <b-form-input id="input-email" class="txt-control" placeholder="Enter email" v-model="idPlayer"></b-form-input>
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
            <div class="list-container">
                <div class="row row-header-list">
                    <div class="col">
                        <div class="control-contairner justify-left">
                            total: {{total}} Item
                            <button class="btn-tranfer"><<</button>
                            <button class="btn-tranfer"><</button>
                            <div class="current-Page">1</div>
                            <button class="btn-tranfer">></button>
                            <button class="btn-tranfer">>></button>
                        </div>
                    </div>
                    <div class="col">
                        <div class="control-contairner justify-right">
                            <NuxtLink class="btnSearch" :to="{ name: 'itemCreateEditPage', params: { id: '0'}}">Add</NuxtLink>
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
                    <div class="col-category title-list">
                        Category
                    </div>
                    <div class="col-price title-list">
                        Price
                    </div>
                    <div class="col-speed title-list">
                        Speed
                    </div>
                    <div class="col-strenght title-list">
                        Strenght
                    </div>
                    <div class="col-weight title-list">
                        Weight
                    </div>
                    <div class="col-height title-list">
                        Height
                    </div>
                    <div class="col-action title-list">
                        action
                    </div>
                </div>
                <div :style="getBackGround(index)" v-for="(item, index) in itemListDisPlay" class="list-row">
                    <div class="col-id title-list">
                        {{item.id}}
                    </div>
                    <div class="col-name text-email">
                        {{item.name}}
                    </div>
                    <div class="col-category ">
                        {{Category(item.category)}}
                    </div>
                    <div class="col-price ">
                        {{item.priceBuy}} gold
                    </div>
                    <div class="col-speed ">
                        {{item.speed}} km/h
                    </div>
                    <div class="col-strenght ">
                        {{item.strenght}} power
                    </div>
                    <div class="col-weight ">
                        {{item.weight}} kg
                    </div>
                    <div class="col-height ">
                        {{item.height}} cm
                    </div>
                    <div class="col-action">
                        <NuxtLink class="btnEdit" :to="{ name: 'itemCreateEditPage', params: { id: item.id}}">Edit</NuxtLink>
                        <button @click="confirmDelete(item.id)" class="btnDelete" >Delete</button>
                    </div>
                </div>
            </div>    
        </div>
    </div>
</template>
<script>
    const itemAPI= 'https://localhost:44346/api/Items';
    const itemDeleteAPI= 'https://localhost:44346/api/Items/';
    const itemPlayersAPI= 'https://localhost:44346/api/DetailItemLists/idPlayer=';
    import { dellObject } from "../../assets/js/main.js";
    const categoryList=["Food", "Equipment"];
    export default {

        /// <summary>
        /// get list item in api
        /// </summary>
        /// <returns></returns>
        async beforeMount(){
            this.itemList= await fetch(itemAPI)
                .then((res)=>res.json());
            this.itemListDisPlay= this.itemList;
            this.total= this.itemList.length;
            this.setListByIdPlayer();
        },
        data(){
            return{
                itemList: [],
                itemListDisPlay: [],
                backEven:{
                    backgroundColor:"#F6F6F6" 
                },
                backOdd:{
                    backgroundColor:"#ffffff" 
                },
                keyName: '',
                isSearch: true,
                iconSearch: '▼',
                total: 0,
                idPlayer: this.$route.params.id,
            };
        },

        methods: {

            /// <summary>
            /// get back ground color for row Item
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
            /// search Item
            /// </summary>
            /// <returns></returns>
            search(){
                var keyName=this.keyName;
                var idPlayer=this.idPlayer;
                if(keyName.length==0&&idPlayer.length!=0){
                    this.setListByIdPlayer();
                }
                else if(typeof(idPlayer) != 'undefined'&&keyName.length!=0){
                    this.itemListDisPlay= this.itemList.filter(function(item){
                        return item.name.toLowerCase().includes(keyName.toLowerCase());
                    })
                    this.total= this.itemListDisPlay.length;
                }
                else{
                    this.setListByIdPlayer();
                    this.itemListDisPlay= this.itemListDisPlay.filter(function(item){
                        return item.name.toLowerCase().includes(keyName.toLowerCase());
                    })
                    this.total= this.itemListDisPlay.length;
                }
                
            },

            /// <summary>
            /// set item list by id Player
            /// </summary>
            /// <returns></returns>
            async setListByIdPlayer(){
                var id= this.idPlayer;
                if(typeof(id) != 'undefined'){
                    var itemPlayers= await fetch(itemPlayersAPI+id)
                        .then((res)=>res.json());
                    var arrayId = '';
                    itemPlayers.forEach(element => {
                        arrayId+=element.idItem;
                    });
                    this.itemListDisPlay= this.itemList.filter(function(item){
                        return arrayId.includes(item.id);
                    })
                    this.total= this.itemListDisPlay.length;
                }
            },

            /// <summary>
            /// refresh list
            /// </summary>
            /// <returns></returns>
            refresh(){
                this.itemListDisPlay= this.itemList;
            },

            /// <summary>
            /// clear input searchs
            /// </summary>
            /// <returns></returns>
            clear(){
                this.keyName = '';
            },

            /// <summary>
            /// get category by string
            /// </summary>
            /// <returns></returns>
            Category(id){
                return categoryList[id-1];
            },

            /// <summary>
            /// confirm delete Item 
            /// </summary>
            /// <param name="id"></param>
            /// <returns>response.json()</returns>
            confirmDelete(id) {
                if (confirm('Do you want to delete this Admin?')) {
                    this.dellObject(id, itemAPI);
                } else {
                    alert("Cancelled");
                }
            },
            dellObject
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
    .col-category{
        width: 15%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-price{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-speed{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-strenght{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-weight{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .col-height{
        width: 10%;
        height: 100%;
        display: flex;
        align-items: center;
        font-family: Arial;
    }
    .text-email{
        color: #007BFF;
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