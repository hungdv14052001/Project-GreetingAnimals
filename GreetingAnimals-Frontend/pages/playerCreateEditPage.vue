<template>
    <div id="player-create-edit-page">
        <PlayerCreateEdit></PlayerCreateEdit>
    </div>
</template>

<script>
    import PlayerCreateEdit from '../components/Player/PlayerCreateEdit.Vue';
    export default {
        layout: 'default',
        components: { 
            PlayerCreateEdit
        },
        name: 'playerCreateEditPage',
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
    #player-create-edit-page{
        min-height: 635px;
        width: 100%;
        background-color: #F0F0F0;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>
