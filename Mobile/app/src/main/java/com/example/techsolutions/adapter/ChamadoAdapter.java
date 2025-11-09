package com.example.techsolutions.adapter;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import com.example.techsolutions.R;
import com.example.techsolutions.model.ChamadoDTO;
import com.example.techsolutions.model.UsuarioLogadoDTO;
import com.example.techsolutions.ui.ConversaActivity;

import java.util.List;

public class ChamadoAdapter extends RecyclerView.Adapter<ChamadoAdapter.ViewHolder> {

    private final List<ChamadoDTO> chamados;
    private final Context context;
    private final UsuarioLogadoDTO usuario;

    public ChamadoAdapter(List<ChamadoDTO> chamados, Context context, UsuarioLogadoDTO usuario) {
        this.chamados = chamados;
        this.context = context;
        this.usuario = usuario;
    }

    @NonNull
    @Override
    public ChamadoAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_chamado, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ChamadoAdapter.ViewHolder holder, int position) {
        ChamadoDTO chamado = chamados.get(position);

        holder.txtTitulo.setText(chamado.getTitulo());
        holder.txtDescricao.setText(chamado.getDescricao());
        holder.txtStatus.setText("Status: " + chamado.getStatus());

        holder.cardView.setOnClickListener(v -> {
            Intent intent = new Intent(context, ConversaActivity.class);
            intent.putExtra("idChamado", chamado.getIdChamado());
            intent.putExtra("usuarioLogado", usuario);
            context.startActivity(intent);
        });
    }

    @Override
    public int getItemCount() {
        return chamados.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder {
        TextView txtTitulo, txtDescricao, txtStatus;
        CardView cardView;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            txtTitulo = itemView.findViewById(R.id.txtTitulo);
            txtDescricao = itemView.findViewById(R.id.txtDescricao);
            txtStatus = itemView.findViewById(R.id.txtStatus);
            cardView = (CardView) itemView;
        }
    }
}
