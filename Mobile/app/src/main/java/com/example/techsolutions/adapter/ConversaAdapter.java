package com.example.techsolutions.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.techsolutions.R;
import com.example.techsolutions.model.ConversaDTO;
import com.example.techsolutions.model.UsuarioLogadoDTO;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class ConversaAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    private static final int TIPO_ENVIADA = 1;
    private static final int TIPO_RECEBIDA = 2;

    private final List<ConversaDTO> mensagens;
    private final Context context;
    private UsuarioLogadoDTO usuarioLogado;

    public ConversaAdapter(List<ConversaDTO> mensagens, Context context) {
        this.mensagens = mensagens;
        this.context = context;
    }

    public void setUsuarioLogado(UsuarioLogadoDTO usuarioLogado) {
        this.usuarioLogado = usuarioLogado;
    }

    @Override
    public int getItemViewType(int position) {
        ConversaDTO msg = mensagens.get(position);
        if (usuarioLogado != null && msg.getRemetente() != null &&
                msg.getRemetente().getIdUsuario().equals(usuarioLogado.getIdUsuario())) {
            return TIPO_ENVIADA;
        } else {
            return TIPO_RECEBIDA;
        }
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        if (viewType == TIPO_ENVIADA) {
            View view = LayoutInflater.from(context).inflate(R.layout.item_mensagem_enviada, parent, false);
            return new EnviadaViewHolder(view);
        } else {
            View view = LayoutInflater.from(context).inflate(R.layout.item_mensagem_recebida, parent, false);
            return new RecebidaViewHolder(view);
        }
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        ConversaDTO msg = mensagens.get(position);

        if (holder instanceof EnviadaViewHolder) {
            ((EnviadaViewHolder) holder).bind(msg);
        } else if (holder instanceof RecebidaViewHolder) {
            ((RecebidaViewHolder) holder).bind(msg);
        }
    }

    @Override
    public int getItemCount() {
        return mensagens.size();
    }

    private static String formatarHora(String dataHoraIso) {
        try {
            String limpa = dataHoraIso.replace("T", " ").split("\\.")[0];
            SimpleDateFormat formatoEntrada = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.getDefault());
            Date data = formatoEntrada.parse(limpa);
            SimpleDateFormat formatoSaida = new SimpleDateFormat("h:mm a", Locale.getDefault());
            return formatoSaida.format(data);
        } catch (ParseException e) {
            e.printStackTrace();
            return "";
        }
    }

    static class EnviadaViewHolder extends RecyclerView.ViewHolder {
        TextView txtMensagem, txtHora;

        EnviadaViewHolder(View itemView) {
            super(itemView);
            txtMensagem = itemView.findViewById(R.id.txtMensagemEnviada);
            txtHora = itemView.findViewById(R.id.txtHoraEnviada);
        }

        void bind(ConversaDTO msg) {
            txtMensagem.setText(msg.getMensagem());
            txtHora.setText(msg.getDataHoraEnvio() != null ? formatarHora(msg.getDataHoraEnvio()) : "");
        }
    }

    static class RecebidaViewHolder extends RecyclerView.ViewHolder {
        TextView txtMensagem, txtRemetente, txtHora;

        RecebidaViewHolder(View itemView) {
            super(itemView);
            txtMensagem = itemView.findViewById(R.id.txtMensagemRecebida);
            txtRemetente = itemView.findViewById(R.id.txtRemetente);
            txtHora = itemView.findViewById(R.id.txtHoraRecebida);
        }

        void bind(ConversaDTO msg) {
            txtMensagem.setText(msg.getMensagem());
            txtRemetente.setText(msg.getRemetente() != null ? msg.getRemetente().getNome() : "Desconhecido");
            txtHora.setText(msg.getDataHoraEnvio() != null ? formatarHora(msg.getDataHoraEnvio()) : "");
        }
    }
}
