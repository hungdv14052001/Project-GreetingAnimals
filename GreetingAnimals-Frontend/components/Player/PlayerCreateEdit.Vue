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
                            <input class="txt-control" type="text" placeholder="Name" v-model="name" readonly />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Tag
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Tag" v-model="tag" readonly />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Date of birth
                        <div class="date-of-birth-contairner">
                            <b-form-datepicker :date-format-options="{ year: 'numeric', month: 'numeric', day: 'numeric' }" class="date-of-birth" v-model="dateofbirth" readonly ></b-form-datepicker>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Number phone
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Number phone" v-model="numPhone" readonly />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Address
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Address" v-model="address" readonly />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE"></div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Level
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" autocomplete="off" placeholder="Level" v-model="level" readonly/>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Rank
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" autocomplete="off" placeholder="Rank" v-model="rank" readonly/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Gold
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" autocomplete="off" placeholder="Password" v-model="gold" readonly/>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Diamond
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" autocomplete="off" placeholder="Confirm password" v-model="diamond" readonly/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="btnContairner">
            <button @click="oke" class="btn-save">Oke</button>
        </div>
    </div>
</template>
<script>
    import { playerAPI } from "../../assets/js/main.js";
    export default {
        
        /// <summary>
        /// get detail player
        /// </summary>
        /// <returns></returns>
        async beforeMount(){
            if(typeof(this.currentIdPlayer) == 'undefined'){
                this.currentIdPlayer='0';
                this.title= 'Detail player';

            }
            else if(this.currentIdPlayer!='0'){
                var player= await fetch(playerAPI+'/'+this.currentIdPlayer)
                    .then((res)=>res.json());
                this.name = player.name;
                this.tag= player.tag;
                this.dateofbirth= player.dateofbirth;
                this.address= player.address;
                this.numPhone= player.numPhone;
                this.createdDate = player.createdDate;
                this.level= player.level;
                this.rank= player.ranl;
                this.gold= player.gold;
                this.diamond= player.diamond;
                this.rank= player.rank;
                this.title= 'Detail player';
            }
        },
        data(){
            return{
                name: '',
                tag: '',
                dateofbirth: '',
                numPhone: '',
                address: '',
                level: 1,
                rank: 1,
                gold: 1000,
                diamond: 100,
                currentIdPlayer: this.$route.params.id,
                createdDate: '',
                updatedDate: '',
                title: 'Detail player',
            };
        },
        methods: {

            /// <summary>
            /// oke action
            /// </summary>
            oke(){
                this.$router.push("playerListPage");
            },
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