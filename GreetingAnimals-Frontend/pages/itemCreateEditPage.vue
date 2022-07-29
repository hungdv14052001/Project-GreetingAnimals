<template>
    <div id="item-create-edit-page">
        <ItemCreateEdit></ItemCreateEdit>
    </div>
</template>

<script>
    import ItemCreateEdit from '../components/Item/ItemCreateEdit.Vue';
    export default {
        layout: 'default',
        components: { 
            ItemCreateEdit
        },
        name: 'itemCreateEditPage',
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
    #item-create-edit-page{
        min-height: 635px;
        width: 100%;
        background-color: #F0F0F0;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>
