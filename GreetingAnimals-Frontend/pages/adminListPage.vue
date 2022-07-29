<template>
    <div id="admin-list-page">
        <AdminList></AdminList>
    </div>
</template>

<script>
    import AdminList from '../components/Admin/AdminList.Vue';
    export default {
        layout: 'default',
        components: { 
            AdminList
        },
        name: 'adminListPage',
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
    #admin-list-page{
        min-height: 635px;
        width: 100%;
    }
</style>
