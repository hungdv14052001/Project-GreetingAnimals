<template>
    <div id="item-list-page">
        <ItemList></ItemList>
    </div>
</template>

<script>
    import ItemList from '../components/Item/ItemList.Vue';
    export default {
        layout: 'default',
        components: { 
            ItemList
        },
        name: 'itemListPage',
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
    #item-list-page{
        min-height: 635px;
        width: 100%;
    }
</style>
