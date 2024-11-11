<template>
    <div>
      <header class="Nav__header">
        <div class="hideNavBar">
          <NavBar />
        </div>
        <div class="ShowNavBar">
          <MobileNavBar/>
        </div>
      </header>
  
      <RouterView />
      <section class="Hero__bg">
        <Hero />
      </section>
  
      <section class="Delta">
        <Delta />
      </section>
    </div>
  </template>
  
  <script>
  import Hero from '@/components/Hero.vue';
  import Delta from '@/components/Delta.vue';
  import NavBar from '@/components/NavBar.vue';
  import '@/assets/main.css';
  import MobileNavBar from '@/components/MobileNavBar.vue';
  
  export default {
    name: 'Home',
    components: {
      Hero,
      Delta,
      NavBar,
      MobileNavBar
    },
    mounted() {
      //Script Menus
  
      document.addEventListener("DOMContentLoaded", () => {
        const navMenu = document.getElementById("navMenu");
        const navToggle = document.getElementById("navToggle");
  
        navToggle.addEventListener("click", () => {
          navMenu.classList.toggle("show");
        });
      });
    }
  };
  </script>
  
  
  <style scoped>
  *,
  *::before,
  *::after {
    box-sizing: border-box;
  }
  
  body {
    margin-inline: 10rem;
    margin: 0;
  }
  
  a {
    text-decoration: none;
  }
  
  .Nav__header {
    margin: 0;
    padding: 0;
  }
  
  
  .Hero__bg {
    width: 100%;
    height: 450px;
    background: url('@/Images/bg.png');
    background-repeat: no-repeat;
    background-size: cover;
    background-position: center center;
    display: flex;
    align-items: center;
    justify-content: center;
  }
  
  .Delta {
    background-color: #C1B49C;
    width: 100%;
    height: 300px;
    color: #FFF;
    padding-inline: 10rem;
    padding-top: 2.5rem;
  }
  
  @media(width < 1280px) {
    .Delta {
      background-color: #C1B49C;
      width: 100%;
      height: 700px;
      color: #FFF;
      padding-inline: 12rem;
      padding-top: 2.5rem;
    }
    .hideNavBar {
      display: none;
    }
    .ShowNavBar{
      display: block;
    }
  
  }
  
  @media(width > 1280px) {
  
    .hideNavBar {
      display: block;
    }
    .ShowNavBar{
      display: none;
    }
  
  }
  </style>
  