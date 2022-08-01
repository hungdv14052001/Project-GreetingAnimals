<template>
    <div id="admin-create-edit">
        <div class="create-edit-title">
            {{title}}
        </div>
        <b-container class="admin-create-edit-contairner">
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding" >
                    <div class="control-contairnerEdit">
                        Name
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="name"
                            v-bind:class="{'is-invalid': errors.name}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.name}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding" >
                    <div class="control-contairnerEdit">
                        Category
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <select  v-model="category" class="txt-control">
                                <option v-for="categoryDatail in categoryList" v-model="categoryDatail.id">{{categoryDatail.name}}</option>
                            </select>
                        </div>
                    </div>
                </b-form-group>   
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding" >
                    <div class="control-contairnerEdit">
                        Speed
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter strenght" class="txt-control" v-model="speed"
                            v-bind:class="{'is-invalid': errors.speed}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.speed}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Strenght
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter strenght" class="txt-control" v-model="strenght"
                            v-bind:class="{'is-invalid': errors.strenght}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.strenght}}
                    </div>
                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding" >
                    <div class="control-contairnerEdit">
                        Weight
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter weight" class="txt-control" v-model="weight"
                            v-bind:class="{'is-invalid': errors.weight}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.weight}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Height
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter height" class="txt-control" v-model="height"
                            v-bind:class="{'is-invalid': errors.height}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.height}}
                    </div>
                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding" >
                    <div class="control-contairnerEdit">
                        Price
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter price" class="txt-control" v-model="priceBuy"
                            v-bind:class="{'is-invalid': errors.priceBuy}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.priceBuy}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Sale
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="priceSale"
                            v-bind:class="{'is-invalid': errors.name}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.priceSale}}
                    </div>
                </b-form-group>
            </b-form>
        </b-container>
        <div class="btnContairner">
            <button @click="doSave" class="btn-save">Save</button>
            <button @click="clear" class="btn-clear">Clear</button>
        </div>
    </div>
</template>
<script>
    import { postData, putData } from "../../assets/js/main.js";
    const itemAPI= 'https://localhost:44346/api/Items';
    const categoryList=[{id: 1 , name:"Food"}, {id: 2 , name:"Equipment"}];
    export default {

        /// <summary>
        /// get admin
        /// </summary>
        /// <returns></returns>
        async beforeMount(){
            this.category= this.categoryList.find(x=>x.id==1).name;
            if(typeof(this.currentIdItem) == 'undefined'){
                this.currentIdItem='0';
                this.title= 'Add item';
            }
            else if(this.currentIdItem!='0'){
                var item= await fetch(itemAPI+'/'+this.currentIdItem)
                    .then((res)=>res.json());
                this.name = item.name;
                this.category= this.categoryList.find(x=>x.id===item.category).name;
                this.speed= item.speed;
                this.strenght= item.strenght;
                this.weight= item.weight;
                this.height = item.height;
                this.priceBuy = item.priceBuy;
                this.priceSale= item.priceSale;
                this.image= item.image;
                this.createdDate = item.createdDate;
                this.title= 'Edit item';
            }
        },

        data(){
            return{
                name: '',
                category: '',
                speed: 0,
                strenght: 0,
                weight: 0,
                height: 0,
                priceBuy: 0,
                priceSale: 0,
                image: '',
                currentIdItem: this.$route.params.id,
                createdDate: '',
                updatedDate: '',
                title: 'Add item',
                errors:{
                    name: '',
                    category: '',
                    speed: '',
                    strenght: '',
                    weight: '',
                    height: '',
                    priceBuy: '',
                    priceSale: '',
                },
                categoryList: categoryList,
            };
        },
        methods: {

            /// <summary>
            /// clear controls input
            /// </summary>
            clear(){
                this.name='';
                this.speed=0;
                this.strenght=0;
                this.weight=0;
                this.height=0;
                this.priceBuy=0;
                this.priceSale=0;
            },

            /// <summary>
            /// do Save action
            /// </summary>
            doSave(){
                var resultCheck= this.checkValidate();
                if(!resultCheck){
                    return;
                }
                var item= {
                    id: this.currentIdItem,
                    name: this.name,
                    category: this.categoryList.find(x=>x.name===this.category).id,
                    speed: this.speed,
                    strenght: this.strenght,
                    weight: this.weight,
                    height: this.height,
                    priceBuy: this.priceBuy,
                    priceSale: this.priceSale,
                    image: this.name+'.png',
                    createdDate: new Date(),
                    updatedDate: new Date(),
                }
                if(this.currentIdItem==0){
                    this.create(item);
                }
                else{
                    item.createdDate=this.createdDate;
                    this.edit(item);
                    alert("Successful edit!");
                    this.$router.push("itemListPage");
                }
            },

            /// <summary>
            /// check validate input
            /// </summary>
            /// <return></return>
            checkValidate(){
                this.errors={
                    name: '',
                    category: '',
                    speed: '',
                    strenght: '',
                    weight: '',
                    height: '',
                    priceBuy: '',
                    priceSale: '',
                }
                var result= true;
                if(!this.name){
                    this.errors.name='Enter name!';
                    result= false;
                }
                if(!this.speed){
                    this.errors.speed='Enter date of speed!';
                    result= false;
                }
                if(!this.strenght){
                    this.errors.strenght='Enter number strenght!';
                    result= false;
                }
                if(!this.weight){
                    this.errors.weight='Enter weight!';
                    result= false;
                }
                if(!this.height){
                    this.errors.height='Enter height!';
                    result= false;
                }
                if(!this.priceBuy){
                    this.errors.priceBuy='Enter priceBuy!';
                    result= false;
                }
                if(!this.priceSale){
                    this.errors.priceSale='Enter priceSale!';
                    result= false;
                }
                return result;
            },

            /// <summary>
            /// Create new Item in Api
            /// </summary>
            /// <param name="dataAdmin"></param>
            create(dataItem){
                this.postData(itemAPI, dataItem)
                        .then(data => {
                            alert("Successful add!");
                            this.$router.push("itemListPage");
                        });
            },

            /// <summary>
            /// edit current Item in Api
            /// </summary>
            /// <param name="dataAdmin"></param>
            /// <returns></returns>
            async edit(dataItem){
                this.putData(itemAPI+'/'+this.currentIdItem, dataItem)
                        .then(data => {
                            
                        });
            },

            postData,
            putData,
        }
    }

</script>
<style>
    #admin-create-edit{
        min-height: 585px;
        width: calc(100% - 50px);
        background-color: white;
        border-radius: 3px;
        border: 1px solid #ccc;
    }
    .create-edit-title{
        height: 45px;
        width: 100%;
        padding: 0 30px;
        color: #007BFF;
        display: flex;
        align-items: center;
        font-weight: bold;
        border-bottom: 1px solid #ccc;
    }
    .admin-create-edit-contairner{
        padding-top: 45px;
        min-height: 470px;
    }
    .row-controlE{
        
    }
    .control-contairnerE{
        display: flex;
        height: 100%;
        justify-content: right;
        align-items: center;
        padding-right: 15%;
        margin-top: 30px;
    }
    .control-padding{
        padding-right: 80px;
        padding-bottom: 15px
    }
    .control-contairnerEdit{
        width: 100%;
        display: flex;
        align-items: center;
        justify-content: right;
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
    .ml10{
        margin-left: 10px;
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
    .icon-item{
        width: 15px;
        height: 15px;
        background-color: #495057;
    }
    .btnContairner{
        display: flex;
        justify-content: center;
        align-items: center;
        min-height: 50px;
        border-top: 1px solid #ccc;
        width: 100%;

    }
    .btn-save{
        background-color: #007BFF;
        color: white;
        border-radius: 3px;
        padding: 4px 15px;
        border: none;
        margin-right: 10px;
    }
    .btn-clear{
        background-color: white;
        color: #007BFF;
        border: 1px solid #007BFF;
        border-radius: 3px;
        padding: 3px 15px;
        margin-left: 10px;
    }
    .date-of-birth{
        width: 320px;
        margin-left: 10px;
    }
    .row-Validate{
        
    }
    .validate-edit{
        position: absolute;
        color: red;
        width: 300px;
        margin-left: calc( 100% - 380px );
    }
</style>