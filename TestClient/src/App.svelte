<script lang="ts">
  import Numbers from './lib/Numbers.svelte';
  import { Button, TextInput, Tile } from 'carbon-components-svelte';
  import 'carbon-components-svelte/css/all.css';

  let baseUrl: string = 'http://localhost:8080';

  let value: string;
</script>

<main>
  <Tile>
    <div>Current baseUrl: {baseUrl}</div>
    <TextInput
      labelText="Server host"
      bind:value
    />
    <br>
    <Button on:click={() => (baseUrl = value)}>Apply</Button>
  </Tile>
  <br /><br /><br />

  <Numbers bind:baseUrl></Numbers>
</main>
