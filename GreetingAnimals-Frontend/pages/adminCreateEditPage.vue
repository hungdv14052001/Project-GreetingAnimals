<template>
    <div id="admin-create-edit-page">
        <AdminCreateEdit></AdminCreateEdit>
    </div>
</template>

<script>
    import AdminCreateEdit from '../components/Admin/AdminCreateEdit.Vue';
    export default {
        layout: 'default',
        components: { 
            AdminCreateEdit
        },
        name: 'adminCreateEditPage',
        async beforeMount(){
            this.id= localStorage.getItem('id');
            this.token= localStorage.getItem('token');
        },
        data(){
            return{
                id: '',
                token: '',
            };
        },
        methods: {
            
        }
    }
</script>
<style>
    #admin-create-edit-page{
        min-height: 635px;
        width: 100%;
        background-color: #F0F0F0;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>
