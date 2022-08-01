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
                            <b-form-input
                            placeholder="Enter name" 
                            class="txt-control" 
                            v-model="name" 
                            v-bind:class="{'is-invalid': errors.name}"
                            v-validate="'required|alpha'"
                            ></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.name}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Email
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="email"
                            v-bind:class="{'is-invalid': errors.email}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.email}}
                    </div>
                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Birth day
                        <b-form-datepicker :date-format-options="{ year: 'numeric', month: 'numeric', day: 'numeric' }" v-model="dateofbirth" class="date-of-birth"
                        v-bind:class="{'is-invalid': errors.dateofbirth}"
                        v-validate="'required|alpha'"></b-form-datepicker>
                    </div>
                    <div class="validate-edit">
                        {{errors.dateofbirth}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Number phone
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input placeholder="Enter name" class="txt-control" v-model="numPhone"
                            v-bind:class="{'is-invalid': errors.numPhone}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.numPhone}}
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
                            <b-form-input  placeholder="Enter name" class="txt-control" v-model="address"
                            v-bind:class="{'is-invalid': errors.address}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.address}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">

                </b-form-group>
            </b-form>
            <b-form class="row row-controlE">
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Password
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input type="password"  placeholder="Enter name" class="txt-control" v-model="passwordAdmin"
                            v-bind:class="{'is-invalid': errors.passwordAdmin}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.passwordAdmin}}
                    </div>
                </b-form-group>
                <b-form-group class="col control-padding">
                    <div class="control-contairnerEdit">
                        Confirm password
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <b-form-input type="password" placeholder="Enter name" class="txt-control" v-model="confirmPassword"
                            v-bind:class="{'is-invalid': errors.confirmPassword}"
                            v-validate="'required|alpha'"></b-form-input>
                        </div>
                    </div>
                    <div class="validate-edit">
                        {{errors.confirmPassword}}
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
    import { adminAPI, postData, putData } from "../../assets/js/main.js";
    export default {
        /// <summary>
        /// get admin
        /// </summary>
        /// <returns></returns>
        async beforeMount(){
            if(typeof(this.currentIdAdmin) == 'undefined'){
                this.currentIdAdmin='0';
                this.title= 'Add admin';
            }
            else if(this.currentIdAdmin!='0'){
                var admin= await fetch(adminAPI+'/'+this.currentIdAdmin)
                    .then((res)=>res.json());
                this.name = admin.name;
                this.email= admin.email;
                this.dateofbirth= admin.dateofbirth;
                this.address= admin.address;
                this.numPhone= admin.numPhone;
                this.createdDate = admin.createdDate;
                this.title= 'Edit admin';
            }
        },
        data(){
            return{
                name: '',
                email: '',
                dateofbirth: '',
                numPhone: '',
                address: '',
                passwordAdmin: '',
                confirmPassword: '',
                currentIdAdmin: this.$route.params.id,
                createdDate: '',
                updatedDate: '',
                title: 'Add admin',
                errors:{
                    name: '',
                    email: '',
                    dateofbirth: '',
                    numPhone: '',
                    address: '',
                    passwordAdmin: '',
                    confirmPassword: '',
                }
            };
        },
        methods: {

            /// <summary>
            /// clear control
            /// </summary>
            clear(){
                this.name= '';
                this.email= '';
                this.numPhone= '';
                this.address= '';
                this.passwordAdmin= '';
                this.confirmPassword= '';
                this.currentIdAdmin='0';
                this.title= 'Add admin';
            },

            /// <summary>
            /// do Save action
            /// </summary>
            doSave(){
                var resultCheck= this.checkValidate();
                if(!resultCheck){
                    return;
                }
                if(this.passwordAdmin!=this.confirmPassword){
                    alert('The entered passwords do not match!');
                    return;
                }
                var admin= {
                    id: this.currentIdAdmin,
                    name: this.name,
                    email: this.email,
                    dateofbirth: this.dateofbirth,
                    numPhone: this.numPhone,
                    address: this.address,
                    password: this.passwordAdmin,
                    createdDate: new Date(),
                    updatedDate: new Date(),
                }
                if(this.currentIdAdmin==0){
                    this.create(admin);
                }
                else{
                    admin.createdDate=this.createdDate;
                    this.edit(admin);
                    alert("Successful edit!");
                    this.$router.push("adminListPage");
                }
            },

            /// <summary>
            /// check validate controls
            /// </summary>
            /// <return>bool</return>
            checkValidate(){
                this.errors={
                    name: '',
                    email: '',
                    dateofbirth: '',
                    numPhone: '',
                    address: '',
                    passwordAdmin: '',
                    confirmPassword: '',
                }
                var result= true;
                if(!this.name){
                    this.errors.name='Enter name!';
                    result= false;
                }
                if(!this.email){
                    this.errors.email='Enter email!';
                    result= false;
                }
                if(!this.dateofbirth){
                    this.errors.dateofbirth='Enter date of birth!';
                    result= false;
                }
                if(!this.numPhone){
                    this.errors.numPhone='Enter number phone!';
                    result= false;
                }
                if(!this.address){
                    this.errors.address='Enter address!';
                    result= false;
                }
                if(!this.passwordAdmin){
                    this.errors.passwordAdmin='Enter password!';
                    result= false;
                }
                if(!this.confirmPassword){
                    this.errors.confirmPassword='Enter confirm password!';
                    result= false;
                }
                return result;
            },

            /// <summary>
            /// Create new Admin in Api
            /// </summary>
            /// <param name="dataAdmin"></param>
            create(dataAdmin){
                postData(adminAPI, dataAdmin)
                    .then(data => {
                        alert("Successful add!");
                        this.$router.push("adminListPage");
                    });
            },

            /// <summary>
            /// edit current Admin in Api
            /// </summary>
            /// <param name="dataAdmin"></param>
            /// <returns></returns>
            async edit(dataAdmin){
                putData(adminAPI+'/'+this.currentIdAdmin, dataAdmin)
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