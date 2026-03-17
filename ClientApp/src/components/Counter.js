import React, { Component } from 'react';
import { endpoints } from '../http/Datosenpoints';

const metodoBadge = (ruta) => {
  const m = ruta.split(' ')[1]?.toUpperCase() || 'GET';
  const colores = {
    POST: { bg: '#e6f4ea', color: '#1a7f37', border: '#82c89a' },
    GET: { bg: '#e8f0fe', color: '#1a56db', border: '#93b4f7' },
    PUT: { bg: '#fff8e1', color: '#b45309', border: '#f5c842' },
    DELETE: { bg: '#fde8e8', color: '#c0392b', border: '#f5a3a3' },
  };
  const s = colores[m] || colores.GET;
  return { metodo: m, ...s };
};

export class Counter extends Component {
  static displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { abierto: null };
  }

  toggle(i) {
    this.setState(prev => ({ abierto: prev.abierto === i ? null : i }));
  }

  render() {
    const { abierto } = this.state;

    const styles = {
      wrapper: {
        fontFamily: "'JetBrains Mono', 'Fira Code', monospace",
        maxWidth: 720,
        margin: '2rem auto',
        padding: '0 1rem',
      },
      titulo: {
        fontSize: 13,
        fontWeight: 600,
        letterSpacing: '0.15em',
        textTransform: 'uppercase',
        color: '#888',
        marginBottom: '1.25rem',
      },
      card: {
        border: '1px solid #e2e8f0',
        borderRadius: 10,
        marginBottom: 10,
        overflow: 'hidden',
        background: '#fff',
        boxShadow: '0 1px 3px rgba(0,0,0,0.06)',
        transition: 'box-shadow 0.2s',
      },
      header: (activo) => ({
        display: 'flex',
        alignItems: 'center',
        gap: 12,
        padding: '13px 16px',
        cursor: 'pointer',
        background: activo ? '#f8faff' : '#fff',
        borderBottom: activo ? '1px solid #e2e8f0' : 'none',
        transition: 'background 0.15s',
        userSelect: 'none',
      }),
      badge: (s) => ({
        fontSize: 11,
        fontWeight: 700,
        padding: '3px 9px',
        borderRadius: 5,
        background: s.bg,
        color: s.color,
        border: `1px solid ${s.border}`,
        letterSpacing: '0.05em',
        minWidth: 52,
        textAlign: 'center',
      }),
      ruta: {
        flex: 1,
        fontSize: 14,
        fontWeight: 500,
        color: '#1e293b',
      },
      chevron: (activo) => ({
        fontSize: 12,
        color: '#94a3b8',
        transform: activo ? 'rotate(180deg)' : 'rotate(0deg)',
        transition: 'transform 0.2s',
      }),
      body: {
        padding: '14px 16px',
        background: '#f8faff',
      },
      label: {
        fontSize: 11,
        fontWeight: 600,
        letterSpacing: '0.1em',
        textTransform: 'uppercase',
        color: '#94a3b8',
        marginBottom: 5,
        marginTop: 12,
      },
      url: {
        fontSize: 13,
        color: '#2563eb',
        background: '#eff6ff',
        border: '1px solid #bfdbfe',
        borderRadius: 6,
        padding: '7px 12px',
        wordBreak: 'break-all',
      },
      pre: {
        fontSize: 12,
        background: '#0f172a',
        color: '#e2e8f0',
        borderRadius: 8,
        padding: '14px 16px',
        margin: 0,
        overflowX: 'auto',
        lineHeight: 1.7,
      },
    };

    return (
      <div style={styles.wrapper}>
        <div style={styles.titulo}>API Endpoints — carritonet</div>

        {endpoints.map((ep, i) => {
          const activo = abierto === i;
          const { metodo, ...badge } = metodoBadge(ep.ruta);
          const nombre = ep.ruta.replace(/ Post| Get| Put| Delete/i, '').trim();

          return (
            <div key={i} style={styles.card}>
              <div style={styles.header(activo)} onClick={() => this.toggle(i)}>
                <span style={styles.badge(badge)}>{metodo}</span>
                <span style={styles.ruta}>{nombre}</span>
                <span style={styles.chevron(activo)}>▼</span>
              </div>

              {activo && (
                <div style={styles.body}>
                  <div style={styles.label}>URL</div>
                  <div style={styles.url}>{ep.link}</div>

                  {ep.body && (
                    <>
                      <div style={styles.label}>Body</div>
                      <pre style={styles.pre}>
                        {JSON.stringify(ep.body, null, 2)}
                      </pre>
                    </>
                  )}
                </div>
              )}
            </div>
          );
        })}
      </div>
    );
  }
}