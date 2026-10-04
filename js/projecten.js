const laadProjecten = async () => {
  try {
    const response = await fetch("data/projecten.json");
    if (!response.ok) throw new Error(`HTTP-fout: ${response.status}`);
    const projecten = await response.json();
    console.log(projecten);
  } catch (fout) {
    console.error("Projecten laden mislukt:", fout);
  }
};

laadProjecten();