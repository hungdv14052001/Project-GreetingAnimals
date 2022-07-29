<template>
    <div id="menu-app">
        <div class="menu-item menu-itemM">
            <i class="mr"></i>
            Home
        </div>
        <div class="menu-item color-blue text-bold">
            Module
        </div>
        <NuxtLink to="adminListPage" class="menu-item menu-itemM">
            <i class="mr"></i>
            Admin
        </NuxtLink>
        <NuxtLink to="playerListPage" class="menu-item menu-itemM">
            <i class="mr"></i>
            Player
        </NuxtLink>
        <NuxtLink to="itemListPage" class="menu-item menu-itemM">
            <i class="mr"></i>
            Item
        </NuxtLink>
    </div>
</template>
<script>
    
</script>
<style>
    #menu-app{
        width: 230px;
        border-right: 1px solid #ccc;
    }
    .menu-item{
        width: 230px;
        padding: 0 26px;
        height: 45px;
        display: flex;
        align-items: center;
        color: black;
    }
    .menu-itemM:hover{
        color: black;
        text-decoration: none;
        background-color: #f0f0f0;
        cursor: pointer;
    }
    .mr{
        margin-right: 7px;
        width: 15px;
        height: 15px;
        background-color: black;
    }
    .color-blue{
        color: #007BFF;
    }
    .text-bold{
        font-weight: bold;
    }
</style>