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
                        Email
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Email" v-model="email" />
                        </div>
                    </div>
                    <div v-if="isEmail" class="validate-contairner">
                        <div class="validate-text">*Enter email</div>
                    </div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Date of birth
                        <div class="date-of-birth-contairner">
                            <b-form-datepicker :date-format-options="{ year: 'numeric', month: 'numeric', day: 'numeric' }" class="date-of-birth" v-model="dateofbirth"></b-form-datepicker>
                        </div>
                    </div>
                    <div v-if="isDate" class="validate-contairner">
                        <div class="validate-text">*Enter date of birth</div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        Number phone
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="text" placeholder="Number phone" v-model="numPhone" />
                        </div>
                    </div>
                    <div v-if="isNumPhone" class="validate-contairner">
                        <div class="validate-text">*Enter number phone</div>
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
                            <input class="txt-control" type="text" placeholder="Address" v-model="address" />
                        </div>
                    </div>
                    <div v-if="isAddress" class="validate-contairner">
                        <div class="validate-text">*Enter address</div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE"></div>
                </div>
            </div>
            <div class="row row-controlE">
                <div class="col">
                    <div class="control-contairnerE">
                        Password
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="password" autocomplete="off" placeholder="Password" v-model="passwordAdmin" required/>
                        </div>
                    </div>
                    <div v-if="isPassword" class="validate-contairner">
                        <div class="validate-text">*Enter password</div>
                    </div>
                </div>
                <div class="col">
                    <div class="control-contairnerE">
                        *Confirm password
                        <div class="iconcontrol ml10">
                            <div class="icon-item"></div>
                        </div>
                        <div class="txt-contairner">
                            <input class="txt-control" type="password" autocomplete="off" placeholder="Confirm password" v-model="confirmPassword" required/>
                        </div>
                    </div>
                    <div v-if="isConfirm" class="validate-contairner">
                        <div class="validate-text">*Enter confirm password</div>
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
                isName: false,
                isEmail: false,
                isDate: false,
                isNumPhone: false,
                isAddress: false,
                isPassword: false,
                isConfirm: false
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
                this.isName = this.checkValidate(this.name);
                this.isEmail = this.checkValidate(this.email);
                this.isNumPhone = this.checkValidate(this.numPhone);
                this.isDate = this.checkValidate(this.dateofbirth);
                this.isAddress = this.checkValidate(this.address);
                this.isPassword = this.checkValidate(this.passwordAdmin);
                this.isConfirm = this.checkValidate(this.confirmPassword);
                if(this.isName||this.isEmail||this.isNumPhone||this.isDate||this.isAddress||this.isPassword||this.isConfirm){
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
            checkValidate(value){
                if(value.length==0){
                    return true;
                }
                else{
                    return false;
                }
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
            pushData,
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