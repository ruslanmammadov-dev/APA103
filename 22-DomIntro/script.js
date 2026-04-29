const card = document.createElement('div');
Object.assign(card.style, {
    width: '350px',
    fontFamily: 'Segoe UI, Tahoma, Geneva, Verdana, sans-serif',
    borderRadius: '12px',
    overflow: 'hidden',
    boxShadow: '0 10px 25px rgba(0,0,0,0.1)',
    backgroundColor: '#fff',
    margin: '20px'
});

const imageArea = document.createElement('div');
Object.assign(imageArea.style, {
    height: '230px',
    backgroundImage: 'url("https://images.unsplash.com/photo-1518780664697-55e3ad937233?auto=format&fit=crop&q=80&w=1000")',
    backgroundSize: 'cover',
    backgroundPosition: 'center',
    position: 'relative'
});

const body = document.createElement('div');
body.style.padding = '20px';

const type = document.createElement('div');
type.innerText = 'DETACHED HOUSE • 5Y OLD';
Object.assign(type.style, { fontSize: '11px', fontWeight: '800', color: '#607d8b', letterSpacing: '0.5px' });

const price = document.createElement('div');
price.innerText = '$750,000';
Object.assign(price.style, { fontSize: '32px', fontWeight: 'bold', margin: '10px 0 5px 0', color: '#2c3e50' });

const address = document.createElement('div');
address.innerText = '742 Evergreen Terrace';
Object.assign(address.style, { fontSize: '16px', color: '#90a4ae', marginBottom: '20px' });

const stats = document.createElement('div');
Object.assign(stats.style, { display: 'flex', gap: '20px', padding: '15px 0', borderTop: '1px solid #eee' });

const bed = document.createElement('div');
bed.innerHTML = `🛏️ <b style="color:#333">3</b> <span style="color:#888">Bedrooms</span>`;
const bath = document.createElement('div');
bath.innerHTML = `🛁 <b style="color:#333">2</b> <span style="color:#888">Bathrooms</span>`;

stats.append(bed, bath);

const footer = document.createElement('div');
Object.assign(footer.style, {
    display: 'flex',
    alignItems: 'center',
    padding: '15px 20px',
    backgroundColor: '#fcfcfc',
    borderTop: '1px solid #eee'
});

const avatar = document.createElement('img');
avatar.src = 'https://i.pravatar.cc/150?u=tiffany';
Object.assign(avatar.style, { width: '40px', height: '40px', borderRadius: '50%', marginRight: '12px' });

const info = document.createElement('div');
info.innerHTML = `<div style="font-weight:bold; font-size:14px">Tiffany Heffner</div>
                  <div style="color:#999; font-size:12px">(555) 555-4321</div>`;

footer.append(avatar, info);

body.append(type, price, address, stats);
card.append(imageArea, body, footer);

document.body.appendChild(card);