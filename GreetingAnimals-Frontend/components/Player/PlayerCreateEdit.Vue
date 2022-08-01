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
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="name"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Tag
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter tag" class="txt-control" v-model="tag"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Birth day
                        <b-form-datepicker :date-format-options="{ year: 'numeric', month: 'numeric', day: 'numeric' }" v-model="dateofbirth" class="date-of-birth"></b-form-datepicker>
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Number phone
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input placeholder="Enter number phone" class="txt-control" v-model="numPhone"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Address
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter address" class="txt-control" v-model="address"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">

                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding" >
                    <div class="control-contairnerEdit">
                        Level
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter level" class="txt-control" v-model="level"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Rank
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="rank"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding" >
                    <div class="control-contairnerEdit">
                        Gold
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="gold"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Diamond
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="diamond"></b-form-input>
                        </div>
                    </div>
                </b-form-group>
            </b-form>
        </b-container>
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
</style>