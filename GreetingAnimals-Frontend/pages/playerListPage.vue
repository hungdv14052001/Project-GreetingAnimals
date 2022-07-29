<template>
    <div id="admin-list-page">
        <PlayerList></PlayerList>
    </div>
</template>

<script>
    import PlayerList from '../components/Player/PlayerList.Vue';
    export default {
        layout: 'default',
        components: { 
            PlayerList
        },
        name: 'playerListPage',
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
