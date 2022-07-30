<template>
    <div id="admin-create-edit">
        <div class="create-edit-title">
            {{title}}
        </div>
        <div class="admin-create-edit-contairner">
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Name
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Name" v-model="name" />
                        </div>
                    </div>
                    <div v-if="isName" class="validate-contairner">
                        <div class="validate-text">*Enter name</div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
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
                    <div v-if="isCategory" class="validate-contairner">
                        <div class="validate-text">*Enter category</div>
                    </div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Speed
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Speed" v-model="speed" />
                        </div>
                    </div>
                    <div v-if="isSpeed" class="validate-contairner">
                        <div class="validate-text">*Enter speed</div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Strenght
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Strenght" v-model="strenght" />
                        </div>
                    </div>
                    <div v-if="isStrenght" class="validate-contairner">
                        <div class="validate-text">*Enter strenght</div>
                    </div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Weight
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Weight" v-model="weight" />
                        </div>
                    </div>
                    <div v-if="isWeight" class="validate-contairner">
                        <div class="validate-text">*Enter weight</div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Height
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Height" v-model="height" />
                        </div>
                    </div>
                    <div v-if="isHeight" class="validate-contairner">
                        <div class="validate-text">*Enter height</div>
                    </div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Price
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Price" v-model="priceBuy" />
                        </div>
                    </div>
                    <div v-if="isBuy" class="validate-contairner">
                        <div class="validate-text">*Enter price buy</div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Sale
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Sale" v-model="priceSale" />
                        </div>
                    </div>
                    <div v-if="isSale" class="validate-contairner">
                        <div class="validate-text">*Enter sale</div>
                    </div>
                </div>
            </div>
        </div>
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
                isName: false,
                isCategory: false,
                isSpeed: false,
                isStrenght: false,
                isWeight: false,
                isHeight: false,
                isBuy: false,
                isSale: false,
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
                this.isName = this.checkValidate(this.name);
                this.isCategory = this.checkValidate(this.category);
                this.isSpeed = this.checkValidate(this.speed);
                this.isStrenght = this.checkValidate(this.strenght);
                this.isWeight = this.checkValidate(this.weight);
                this.isHeight = this.checkValidate(this.height);
                this.isBuy = this.checkValidate(this.priceBuy);
                this.isSale = this.checkValidate(this.priceSale);
                if(this.isName||this.isCategory||this.isSpeed||this.isStrenght||this.isWeight||this.isHeight||this.isBuy||this.isSale){
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
            checkValidate(value){
                if(value.length==0){
                    return true;
                }
                else{
                    return false;
                }
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
        min-height: 470px;
    }
    .row-controlE{
        
    }
    .control-contairnerE{
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: right;
        align-items: center;
        padding-right: 15%;
        margin-top: 30px;
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
    .file-input{
        height: 34px;
        width: 320px;
        margin-left: 10px;
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
    .date-of-birth-contairner{
        width: 320px;
        margin-left: 10px;
    }
    .row-Validate{
        
    }
    .validate-contairner{
        position: absolute;
        display: flex;
        width: 100%;
        justify-content: right;
        align-items: center;
        padding-right: 15%;
        margin-top: -15px;
    }
    .validate-text{
        width: 300px;
        color: red;
    }
</style>