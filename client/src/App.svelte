<script lang="ts">
  import logo from './assets/svelte.png'
  // import Counter from './lib/Counter.svelte'
  import { onMount } from "svelte";
  import { apiData, gameMasters } from './store/store'

  onMount(async () => {
    fetch("http://localhost:5000/GameMasters/")
      .then(response => response.json())
      .then(data => {
        console.log(data);
        apiData.set(data);
      }).catch(error => {
        return [];
      });
  });
</script>

<main>
  <img src={logo} alt="Svelte Logo" />
  <ul>
    {#each $gameMasters as gm}
    <li>{gm}</li>
    {/each}
  </ul>
</main>

<style>
  :root {
    font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen,
      Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  }

  main {
    text-align: center;
    padding: 1em;
    margin: 0 auto;
  }

  img {
    height: 16rem;
    width: 16rem;
  }

  h1 {
    color: #ff3e00;
    text-transform: uppercase;
    font-size: 4rem;
    font-weight: 100;
    line-height: 1.1;
    margin: 2rem auto;
    max-width: 14rem;
  }

  p {
    max-width: 14rem;
    margin: 1rem auto;
    line-height: 1.35;
  }

  @media (min-width: 480px) {
    h1 {
      max-width: none;
    }

    p {
      max-width: none;
    }
  }
</style>
