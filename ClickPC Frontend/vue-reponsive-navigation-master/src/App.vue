<template>
  <div id="app">
    <ResponsiveNavigation
      :nav-links="navLinks"
      :image-path="require('./assets/logo.png')"
      background="#fff"
      link-color="#777"
      hoverBackground="#ddd"
    />
    <router-view />
    <div id="footer">
      <p>Copyright (c) 2021 ERP Master Designers, all rights reserved</p>
      </div> 
  </div>
  
</template>

<script>
import ResponsiveNavigation from "@/components/ResponsiveNavigation";

export default {
  components: {
    ResponsiveNavigation,
  },
  data: () => ({
    navLinks: [
      {
        text: "CEO",
        path: "/ceo",
       // icon: "ion-ios-business",
      },
      {
        text: "Sales Manager",
        path: "/salesmanager",
       // icon: "ion-ios-business",
      },
      {
        text: "Purchasing Manager ",
        path: "/PurshasingManager",
        //icon: "ion-ios-bonfire",
      },
    ],
  }),
};
</script>

<style lang="scss">
@import "https://unpkg.com/ionicons@4.2.2/dist/css/ionicons.min.css";

@import "../node_modules/@syncfusion/ej2-base/styles/material.css";
@import "../node_modules/@syncfusion/ej2-inputs/styles/material.css";
@import "../node_modules/@syncfusion/ej2-vue-dropdowns/styles/material.css";
@import "../node_modules/@syncfusion/ej2-vue-lists/styles/material.css";
@import "../node_modules/@syncfusion/ej2-vue-navigations/styles/material.css";

figure {
  margin-block-start: 0;
  margin-block-end: 0;
  margin-inline-start: 10px;
  margin-inline-end: 0;
}

body {
  margin: 0;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;
  a {
    font-weight: bold;
    color: #2c3e50;
    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
#footer{
    display: table;
    text-align: center;
    margin-left: auto;
    margin-right: auto;
}
</style>
