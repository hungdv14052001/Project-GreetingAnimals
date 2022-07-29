<template>
  <div>
    <div>
      <Header></Header>
    </div>
    <div id="main">
      <Menu></Menu>
      <Nuxt />
    </div>
    <div class="app-footer">
      Copyright © 2021 DevFast
    </div>
  </div>
</template>

<script>
  import Header from '../components/App/Header.Vue';
  import Menu from '../components/App/Menu.Vue';
  import tes from  "../assets/js/main";
  export default {
    components: { 
      Header,
      Menu,
    },
  }
</script>
<style>
  #main{
    display: flex;
    width: 100%;
  }
  .app-footer{
    width: 100%;
    height: 70px;
    display: flex;
    justify-content: center;
    align-items: center;
    color: #fff;
    font-size: 17px;
    font-family: Arial, Helvetica, sans-serif;
    background-color: #303030;
  }
</style>
